using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RegistroNotas.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireNonAlphanumeric = options.Password.RequireDigit = options.Password.RequireUppercase = options.Password.RequireLowercase = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthorizationBuilder()
    .AddDefaultPolicy("Predeterminada", policy => policy.RequireAuthenticatedUser())
    .AddPolicy("Administrador", policy => policy.RequireAuthenticatedUser().RequireRole("Administrador"))
    .AddPolicy("Docente", policy => policy.RequireAuthenticatedUser().RequireRole("Docente"))
    .AddPolicy("Estudiante", policy => policy.RequireAuthenticatedUser().RequireRole("Estudiante"));


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();