using Microsoft.EntityFrameworkCore;
using Expanse.DataAccess.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<ExpanseDbContext>(
    options =>
    {
        options.UseSqlServer(
            builder.Configuration["ConnectionStrings:AzureExpanseDbContextConnection"]);
    }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
var aaaa = app.Environment;
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<ExpanseDbContext>();
DatabaseSeed.Seed(dbContext);



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


/*
 DEV:

zmiana 

Add-Migration SeccProd -OutputDir "Migrations/Dev"
update-database


PROD

Add-Migration SeccProd -OutputDir "Migrations/Prod"
Script-Migration
run script on production database

 
 
 
 */