using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using TrainingPlansWA.Areas.Identity.Data;
using TrainingPlansWA.Data;
using TrainingPlansWA.Models;

namespace TrainingPlansWA.Controllers {
    [Authorize]
    public class PlanCreateController : Controller {

        UserManager<UserModel> _userManager;
        UsersContext UserDB;

        public PlanCreateController(UserManager<UserModel> _userManager, UsersContext UserDB) {
            this._userManager = _userManager;
            this.UserDB = UserDB;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatedPlan createdPlan) {
            var user = await _userManager.GetUserAsync(User);

            if (user == null) {
                return RedirectToAction("Index", "HomePage");
            }

            if (user.CreatedPlans == null) {
                user.CreatedPlans = new List<CreatedPlan>();
            }

            createdPlan.UserId = user.Id;
            createdPlan.ToEdit = false;

            // сохраняем новый план в БД
            user.CreatedPlans.Add(createdPlan);
                await UserDB.SaveChangesAsync();
                await _userManager.UpdateAsync(user);
            //    return RedirectToAction("Index", "Home"); // Перенаправьте пользователя на главную страницу или другую страницу

            return View("Index");
           // return Ok(new { Success = true, Message = "План успешно создан" });

        }
        public IActionResult Index() {
            return View();
        }
    }
}
