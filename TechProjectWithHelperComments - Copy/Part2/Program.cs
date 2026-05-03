using Microsoft.EntityFrameworkCore;
using TechForums; // must match namespace in TechForumsDbContext.cs and LearningSite.cs

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<TechForumsDbContext>(options =>
    options.UseSqlite("Data Source=TechForums.db")); // must match Part2.csproj <None Update="TechForums.db"> — example: <None Update="TechForums.db">

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
