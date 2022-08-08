using AnimePlace.Data;
using AnimePlace.Models;
using AnimePlace.Services;
using AnimePlace.Services.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>

{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireUppercase = false;
    options.Password.RequiredUniqueChars = 0;
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.User.RequireUniqueEmail = true;
})
    //.AddRoles<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IGetCountsService, GetCountsService>();
builder.Services.AddTransient<IAnimesService, AnimesService>();
builder.Services.AddTransient<ICharactersService, CharactersService>();
builder.Services.AddTransient<IProfileService, ProfileService>();
builder.Services.AddTransient<IFavoritesService, FavoritesService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IAddToListService, AddToListService>();
builder.Services.AddAntiforgery();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
