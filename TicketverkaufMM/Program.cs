using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;


// hinzufuegen
using TicketverkaufMM.Data;


//namespace TicketverkaufMM;

//public class Program
//{
//    public static void Main(string[] args)
//    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        //builder.Services.AddControllersWithViews();

///Anfang/// Identity hinzufügen 

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // Passwort-Regeln für Entwicklung 
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;
})
.AddEntityFrameworkStores<ApplicationDbContext>() // >> // AppDbContext ERGÄNZEN
.AddDefaultTokenProviders();

// >> // Globalen Filter: Alles schuetzen!
builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

// Add services to the container
builder.Services.AddControllersWithViews();

//// Register DbContext
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext")));

// Register User Services


///Ende/// Identity hinzufügen 

var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        //Authentication VOR Authorization
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
//    }
//}
