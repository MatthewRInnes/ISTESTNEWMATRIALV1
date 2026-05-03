using Microsoft.EntityFrameworkCore;
using MusicPlatforms;

// Web host — same structure as TechForums Part 2; keep databaseFileName in sync with Part2.csproj (None Update: MusicPlatforms.db).
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<MusicPlatformsDbContext>(options =>
    options.UseSqlite("Data Source=MusicPlatforms.db"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();
