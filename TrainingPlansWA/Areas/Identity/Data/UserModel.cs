using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TrainingPlansWA.Models;

namespace TrainingPlansWA.Areas.Identity.Data;

// Add profile data for application users by adding properties to the User class

public class UserModel : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }

    public List<FavoritePlan> FavoritePlans { get; set; }

    public List<CreatedPlan> CreatedPlans { get; set; }

    public List<Exercise> Exercises { get; set; }

}

