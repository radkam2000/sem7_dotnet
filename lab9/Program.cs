using Lab9.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Lab9.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Lab9IdentityDbContextConnection"); builder.Services.AddDbContext<Lab9IdentityDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<Lab9IdentityDbContext>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IFoxesRepository, FoxesRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseFileServer();

app.MapControllers();
app.MapRazorPages();



using (var scope = app.Services.CreateScope())
{
    using (var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>())
    using (var userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>())
    {
        roleManager.CreateAsync(new IdentityRole("Admin")).Wait();

        foreach (var user in userManager.Users.Where(x => x.Email.EndsWith("@example.com")))
        {
            userManager.AddToRoleAsync(user, "Admin").Wait();
        }
    }
}

app.Run();
