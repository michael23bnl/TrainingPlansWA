// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TrainingPlansWA.Areas.Identity.Data;
using TrainingPlansWA.Data;
using TrainingPlansWA.Models;
using TrainingPlansWA.Controllers;
using System.Numerics;
using Microsoft.EntityFrameworkCore;

namespace TrainingPlansWA.Areas.Identity.Pages.Account.Manage
{
    public class DeletePersonalDataModel : PageModel
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly ILogger<DeletePersonalDataModel> _logger;
        UsersContext UserDB;
        public DeletePersonalDataModel(
            UserManager<UserModel> userManager,
            SignInManager<UserModel> signInManager,
            ILogger<DeletePersonalDataModel> logger,
            UsersContext userDB)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            UserDB = userDB;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [DataType(DataType.Password)]
            [DisplayName("Пароль")]
            public string Password { get; set; }
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public bool RequirePassword { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);
            if (RequirePassword)
            {
                if (!await _userManager.CheckPasswordAsync(user, Input.Password))
                {
                    ModelState.AddModelError(string.Empty, "Incorrect password.");
                    return Page();
                }
            }

            //удаляем упражнения из таблицы упражнений, подвязанной к пользователю (созданные планы)          
            foreach (CreatedPlan cp in UserDB.CreatedPlans.Include(p => p.Exercises)) {
                if (cp.UserId == user.Id) {
                    foreach (Exercise ex in cp.Exercises) {
                        if (ex.Name != null) {
                            UserDB.Exercises.Remove(ex);
                        }
                    }
                }
            }

            //удаляем упражнения из таблицы упражнений, подвязанной к пользователю (избранные планы)          
            foreach (FavoritePlan fp in UserDB.FavoritePlans.Include(p => p.Exercises)) {
                if (fp.UserId == user.Id) {
                    foreach (Exercise ex in fp.Exercises) {
                        if (ex.Name != null) {
                            UserDB.Exercises.Remove(ex);
                        }
                    }
                    Response.Cookies.Delete($"markedPlan_{user.Id}_{fp.CrossDBId}");
                }
            }
          
            var result = await _userManager.DeleteAsync(user);
            var userId = await _userManager.GetUserIdAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleting user.");
            }

            await _signInManager.SignOutAsync();

            _logger.LogInformation("User with ID '{UserId}' deleted themselves.", userId);

            return Redirect("~/");
        }
    }
}
