using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TrainingPlansWA.Areas.Identity.Data;
using TrainingPlansWA.Data;
using TrainingPlansWA.Models;

namespace TrainingPlansWA.Controllers {

    [Authorize]
    public class FavoritesController : Controller {
        UserManager<UserModel> _userManager;
        PlansContext PlanDB;
        UsersContext UserDB;


        public FavoritesController(UserManager<UserModel> userManager, PlansContext PlanDB, UsersContext UserDB) {
            _userManager = userManager;
            this.PlanDB = PlanDB;
            this.UserDB = UserDB;
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> AddToFavorite([FromBody] int planId) { //принимаем ID плана, который хотим добавить в избранное
            
            //идентифицируем пользователя, который добавляет план в избранное

            var user = await _userManager.GetUserAsync(User);
           

            if (user == null) {
                //return RedirectToAction("Index", "HomePage");
                return NotFound(new { Success = false, Message = "Вы должны быть авторизованы, чтобы добавлять планы в избранное" });
            }

            //получаем из БД план с нужным ID вместе с содержащимися в нём упражнениями

            var plan = await PlanDB.Plans
            .Include(p => p.Exercises)
            .SingleOrDefaultAsync(p => p.Id == planId);
           
            if (plan == null) {
                return NotFound(new { Success = false, Message = "План не найден" });
            }

            if (plan.IsFavorite == false) { //если план не помечен как избранный, сохраняем его как избранный и соответствующе помечаем
                plan.IsFavorite = true;

                //формируем новый избранный план на основе полученного плана из БД

                FavoritePlan favoritePlan = new FavoritePlan {
                    UserId = user.Id,
                    CrossDBId = plan.CrossDBId,
                    Category = plan.Category,
                    IsFavorite = true,
                    Exercises = plan.Exercises.Select(e => new Exercise { Name = e.Name }).ToList(),
                };

                //если у пользователя список избранных планов пуст (не создан), то создаём его

                if (user.FavoritePlans == null) {
                    user.FavoritePlans = new List<FavoritePlan>();
                }

                //доавляем план в список избранных планов пользователя

                user.FavoritePlans.Add(favoritePlan);

                //можно и так добавить

                //UserDB.Add(favoritePlan); 

                //UserDB.Entry(user).State = EntityState.Modified;

                //сохраняем изменения в БД

                await _userManager.UpdateAsync(user);

                //можно и так сохранить

                //await UserDB.SaveChangesAsync();

                Response.Cookies.Append($"markedPlan_{user.Id}_{plan.CrossDBId}", "true", new CookieOptions {
                    Path = "/",
                    HttpOnly = false,
                });
            }
            else { //если план уже помечен как избранный, снимаем с него эту отметку и удаляем со страницы избранного
                plan.IsFavorite = false;
                Response.Cookies.Delete($"markedPlan_{user.Id}_{plan.CrossDBId}");
                var fav_plan = await UserDB.FavoritePlans
                .Include(fp => fp.Exercises)
                .FirstOrDefaultAsync(fp => fp.CrossDBId == plan.CrossDBId);
                if (fav_plan == null) {
                    return NotFound(new { Success = false, Message = "Избранный план не найден" });
                }

                //удаляем упражнения плана из таблицы упражнений, подвязанной к пользователю
                foreach (Exercise ex in fav_plan.Exercises) {
                    UserDB.Exercises.Remove(ex);
                }

                // Удаляем план из списка избранных

                user.FavoritePlans.Remove(fav_plan);

                //можно и так удалить

                //UserDB.FavoritePlans.Remove(plan);

                // сохраняем изменения в БД

                await _userManager.UpdateAsync(user);

                //можно и так сохранить

                //await UserDB.SaveChangesAsync();
            }

            //сохраняем изменения в БД

            await PlanDB.SaveChangesAsync();

            return Ok(new { Success = true, Message = "План успешно добавлен в избранное" });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorite([FromBody] int planId) {
            var user = await _userManager.GetUserAsync(User);

            if (user == null) {
                return RedirectToAction("Index", "HomePage");
            }

            // Ищем избранный план для удаления по переданному ID вместе с упражнениями этого плана

            var plan = await UserDB.FavoritePlans
            .Include(fp => fp.Exercises)
            .FirstOrDefaultAsync(fp => fp.Id == planId);

            if (plan == null) {
                return NotFound(new { Success = false, Message = "Избранный план не найден" });
            }

            //находим соответствущий план в каталоге

            var orig_plan = await PlanDB.Plans
            .Include(op => op.Exercises)
            .SingleOrDefaultAsync(op => op.CrossDBId == plan.CrossDBId);

            if (orig_plan == null) {
                return NotFound(new { Success = false, Message = "Избранный план не найден" });
            }

            //снимаем с него отметку избранного

            orig_plan.IsFavorite = false;

            //сохраняем изменения в БД планов

            await PlanDB.SaveChangesAsync();

            //удаляем упражнения плана из таблицы упражнений, подвязанной к пользователю
            foreach (Exercise ex in plan.Exercises) {
                UserDB.Exercises.Remove(ex);
            }

            // Удаляем план из списка избранных            
            user.FavoritePlans.Remove(plan);
            
            
            //можно и так удалить

            //UserDB.FavoritePlans.Remove(plan);

            // сохраняем изменения в БД

            await _userManager.UpdateAsync(user);

            //можно и так сохранить

            //await UserDB.SaveChangesAsync();

            Response.Cookies.Delete($"markedPlan_{user.Id}_{plan.CrossDBId}");

            return Ok(new { Success = true, Message = "План успешно удален из избранного" });
        }

        public async Task<IActionResult> Index() {
            var user = await _userManager.GetUserAsync(User);

            if (user == null) {
                return RedirectToAction("Index", "HomePage");
            }

            var favoritePlans = UserDB.FavoritePlans
                .Where(fp => fp.UserId == user.Id)
                .Include(e => e.Exercises)
                .ToListAsync();

            return View(await favoritePlans);
        }

    }
}
