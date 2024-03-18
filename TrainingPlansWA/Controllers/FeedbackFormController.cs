using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingPlansWA.Models;

namespace TrainingPlansWA.Controllers {
    [Authorize]
    public class FeedbackFormController : Controller {
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult Check(FeedbackFormModel Feedback) {
            if (ModelState.IsValid) {
                return Redirect("/");
            }
            return View("Index");
        }
    }
}
