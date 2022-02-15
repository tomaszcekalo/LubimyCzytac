using LubimyCzytac;
using LubimyCzytac.Model;
using LubimyCzytac.MVC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ML;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddPredictionEnginePool<LubimyCzytacModel.ModelInput, LubimyCzytacModel.ModelOutput>()
    .FromFile("LubimyCzytacModel.zip");
builder.Services.AddSingleton<IBooksRepository, BooksCsvRepository>();
builder.Services.AddSingleton<IReviewsRepository, ReviewsCsvRepository>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();