using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PracticaSemana2.Areas.Identity.Data;
using PracticaSemana2.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PracticaSemana2ContextConnection") ?? throw new InvalidOperationException("Connection string 'PracticaSemana2ContextConnection' not found.");

builder.Services.AddDbContext<PracticaSemana2Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<PracticaSemana2User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<PracticaSemana2Context>();

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    pattern: "{controller=Productos}/{action=Inicio}/{id?}");

app.MapRazorPages();

app.Run();
