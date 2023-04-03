using HatShopWebAppWAzureDB.Data;
using HatShopWebAppWAzureDB.Identity;
using HatShopWebAppWAzureDB.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<HatShopDbContext>(options => 
    options.UseSqlServer(  
        builder.Configuration.GetConnectionString("HatShopDbConnectionString")));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<HatShopDbContext>();
builder.Services.AddTransient(typeof(IHatRepository), typeof(HatRepository));
builder.Services.AddTransient<IHatRepository, HatRepository>();
builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddIdentityCore<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<HatShopDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
