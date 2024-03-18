using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrainingPlansWA.Areas.Identity.Data;
using TrainingPlansWA.Data;
using TrainingPlansWA.Models;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("TrainingPlansWADBContextConnection") ?? throw new InvalidOperationException("Connection string 'TrainingPlansWADBContextConnection' not found.");
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
string connection = builder.Configuration.GetConnectionString("PlansConnection");

builder.Services.AddDbContext<UsersContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<PlansContext>(options => options.UseSqlServer(connection));
builder.Services.AddDefaultIdentity<UserModel>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<UsersContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages(); 

builder.Services.Configure<IdentityOptions>(options => {
    options.Password.RequireUppercase = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HomePage}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
