using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Numerics;
using TrainingPlansWA.Areas.Identity.Data;
using TrainingPlansWA.Data;
using TrainingPlansWA.Models;
using TrainingPlansWA.Controllers;

namespace TrainingPlansWA.Controllers {
    [Authorize]
    public class CreatedPlansController : Controller {

        UserManager<UserModel> _userManager;
        UsersContext UserDB;

        public CreatedPlansController(UserManager<UserModel> _userManager, UsersContext UserDB) {
            this._userManager = _userManager;
            this.UserDB = UserDB;
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromCreations([FromBody] int createdPlanId) {
            var user = await _userManager.GetUserAsync(User);

            if (user == null) {
                return RedirectToAction("Index", "HomePage");
            }

            // Ищем созданный план для удаления по переданному ID вместе с упражнениями этого плана

            var plan = await UserDB.CreatedPlans
           .Include(cp => cp.Exercises)
           .FirstOrDefaultAsync(cp => cp.Id == createdPlanId);

            if (plan == null) {
                return NotFound(new { Success = false, Message = "Избранный план не найден" });
            }

            //удаляем упражнения плана из таблицы упражнений, подвязанной к пользователю
            foreach (Exercise ex in plan.Exercises) {
                UserDB.Exercises.Remove(ex);
            }
            UserDB.CreatedPlans.Remove(plan);

            await _userManager.UpdateAsync(user);
            //    return RedirectToAction("Index", "Home"); // Перенаправьте пользователя на главную страницу или другую страницу


            return Ok(new { Success = true, Message = "План успешно удалён" });

        }

        public class JsonData {
            public int CreatedPlanId { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] JsonData data) {          
            var createdPlanId = data.CreatedPlanId;

            var plan = await UserDB.CreatedPlans
           .Include(cp => cp.Exercises)
           .FirstOrDefaultAsync(cp => cp.Id == createdPlanId);

            if (plan == null) {
                return NotFound(new { Success = false, Message = "Избранный план не найден" });
            }

            plan.ToEdit = true;

            return PartialView("_PlanEditFormPartial", plan);

        }
        
        [HttpPost]
        public async Task<IActionResult> SaveEditedPlan(int planId) {

            var plan = await UserDB.CreatedPlans
           .Include(cp => cp.Exercises)
           .SingleOrDefaultAsync(cp => cp.Id == planId);

            string Category = Request.Form.FirstOrDefault(p => p.Key == "Category").Value;
            
            plan.ToEdit = false;
            plan.Category = Category;

            var Exercises = Request.Form
            .Where(p => p.Key.StartsWith("Exercises["))
            .Select(p => p.Value)
            .ToList();

            //удаляем все предыдущие упражнения данного плана, т.к. старые упражрения не перезаписываются. 
            //в БД добавляются новые упражнения без перезаписи поверх старых, поэтому просто удаляем старые.
            foreach (Exercise ex in plan.Exercises) {
                UserDB.Exercises.Remove(ex);
            }

            plan.Exercises = Exercises.Select(ex => new Exercise { Name = ex }).ToList();
            
            // сохраняем изменения в БД
            await UserDB.SaveChangesAsync();

            var user = await _userManager.GetUserAsync(User);

            if (user == null) {
                return RedirectToAction("Index", "HomePage");
            }

            var createdPlans = UserDB.CreatedPlans
               .Where(cp => cp.UserId == user.Id)
               .Include(e => e.Exercises)
           .ToListAsync();

            var model = new Tuple<IEnumerable<TrainingPlansWA.Models.CreatedPlan>, TrainingPlansWA.Areas.Identity.Data.UserModel>(await createdPlans, user);

            return PartialView("_PlanCardPartial", model);
        }

        public async Task<IActionResult> Index() {
            var user = await _userManager.GetUserAsync(User);

            if (user == null) {
                return RedirectToAction("Index", "HomePage");
            }

            var createdPlans = UserDB.CreatedPlans
                .Where(cp => cp.UserId == user.Id)
                .Include(e => e.Exercises)
            .ToListAsync();

            var model = new Tuple<IEnumerable<TrainingPlansWA.Models.CreatedPlan>, TrainingPlansWA.Areas.Identity.Data.UserModel>(await createdPlans, user);
            return View(model);
        }
    }
}
