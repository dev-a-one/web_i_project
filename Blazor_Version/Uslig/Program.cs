using Microsoft.EntityFrameworkCore;
using Uslig.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. (Default implementaion)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add db
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));


var app = builder.Build();

// Configure the HTTP request pipeline. (Default implementaion)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // (Default implementaion) The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// (Default implementaion) 
//   \|/

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
