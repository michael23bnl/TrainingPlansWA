using Microsoft.EntityFrameworkCore;


namespace TrainingPlansWA.Models {
    public class PlansContext : DbContext {
        public DbSet<Plan> Plans { get; set; } = null!;
        public DbSet<Exercise> Exercises { get; set; } = null!;
        public PlansContext(DbContextOptions<PlansContext> options)
            : base(options) {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        
    }
}
