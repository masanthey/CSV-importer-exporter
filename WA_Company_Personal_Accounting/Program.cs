using Microsoft.EntityFrameworkCore;
using WA_Company_Personal_Accounting.Domain;
using WA_Company_Personal_Accounting.Domain.Repositories.EntityFramework;
using WA_Company_Personal_Accounting.Domain.Repositories.Interfaces;
using WA_Company_Personal_Accounting.Service;


var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Configuration.Bind("Project", new Config());

builder.Services.AddTransient<ICompany, EFCompany>();
builder.Services.AddTransient<IEmployee, EFEmployee>();

builder.Services.AddTransient<DataManager>();

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

