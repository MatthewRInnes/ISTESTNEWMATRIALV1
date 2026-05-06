using Microsoft.EntityFrameworkCore;
using Set01.Songs.Part2;

// This is the “start up” file for the website.
var builder = WebApplication.CreateBuilder(args);

// Razor Pages is what makes Pages/Index.cshtml work.
builder.Services.AddRazorPages();

// This file name MUST match the database file beside the built website.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=Songs.db"));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();
