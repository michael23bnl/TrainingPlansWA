
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPlansWA.Models {
   
    public class Plan {
        public int Id { get; set; }       
        public string CrossDBId { get; set; } = string.Empty;
        public string Category { get; set; }
        public bool IsFavorite { get; set; } = false;
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
    }

    public class Exercise {
        public int Id { get; set; }
        public string Name { get; set; }

        /*public int CreatedPlanID { get; set; }
        public int FavoritePlanID { get; set; }*/
    }

    public class FavoritePlan : Plan {
        [ForeignKey("UserId")]
        public string UserId { get; set; }
      
    }
    [Table("CreatedPlans")]
    public class CreatedPlan {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        public bool ToEdit { get; set; }
        public string Category { get; set; }
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
    }


}
