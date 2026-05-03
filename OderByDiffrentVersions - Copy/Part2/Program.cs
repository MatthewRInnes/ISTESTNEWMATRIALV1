using Microsoft.EntityFrameworkCore;
using LearningPlatforms; // must match namespace in LearningPlatformsDbContext.cs and LearningSite.cs

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<LearningPlatformsDbContext>(options =>
    options.UseSqlite("Data Source=LearningPlatforms.db")); // must match Part2.csproj <None Update="LearningPlatforms.db"> — example: <None Update="LearningPlatforms.db">

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages(); // maps / to Pages/Index.cshtml when @page is present

app.Run();
