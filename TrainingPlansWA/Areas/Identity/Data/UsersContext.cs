using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrainingPlansWA.Areas.Identity.Data;
using TrainingPlansWA.Models;

namespace TrainingPlansWA.Data;

public class UsersContext : IdentityDbContext<UserModel>
{
    //public DbSet<Exercise> Exercises { get; set; } = null!;
    public DbSet<FavoritePlan> FavoritePlans { get; set; } = null!;

    public DbSet<CreatedPlan> CreatedPlans { get; set; } = null!;

    public DbSet<Exercise> Exercises { get; set; } = null!;

    public UsersContext(DbContextOptions<UsersContext> options)
        : base(options)
    {
        Database.EnsureCreated();   // создаем базу данных при первом обращении
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<UserModel>()
        .HasMany(u => u.CreatedPlans)
        .WithOne()
        .HasForeignKey(cp => cp.UserId)
        .OnDelete(DeleteBehavior.Cascade); // Добавлено удаление в cascade, чтобы удаление пользователя привело к удалению связанных планов

        builder.Entity<UserModel>()
            .HasMany(u => u.FavoritePlans)
            .WithOne()
            .HasForeignKey(fp => fp.UserId)
            .OnDelete(DeleteBehavior.Cascade); // Добавлено удаление в cascade, чтобы удаление пользователя привело к удалению связанных избранных планов


        // Другие настройки модели...

        // Убедитесь, что это добавлено, если вы используете миграции для создания базы данных
        //builder.Entity<Plan>().ToTable("Plans");
        //builder.Entity<UserModel>().ToTable("Users");
    }
}
