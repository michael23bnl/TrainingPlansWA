using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TrainingPlansWA.Areas.Identity.Data;
using TrainingPlansWA.Data;
using TrainingPlansWA.Models;
using TrainingPlansWA.Controllers;

namespace TrainingPlansWA.Controllers {
    public class HomePageController : Controller {
        public IActionResult Index() {
            return View();
        }

    }
}
