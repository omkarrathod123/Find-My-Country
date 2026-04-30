using FindMyCountry.Client.Pages;
using FindMyCountry.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FindMyCountry.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FindMyCountryContextDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FindMyCountryContextDB") ?? throw new InvalidOperationException("Connection string 'FindMyCountryContextDB' not found.")));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(FindMyCountry.Client._Imports).Assembly);

app.Run();
