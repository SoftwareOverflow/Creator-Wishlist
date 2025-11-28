using Application.DependencyInjection;
using Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebApp.API.Components;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("DefaultConnection connection string not found");

/*builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();*/

builder.Services.AddInfrastructure(connectionString);
builder.Services.AddApplication();

/*builder.Services.AddScoped<IWishlistRepository, WishlistRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//builder.Services.AddScoped<WishlistService>();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();*/


builder.Services.AddRazorPages();
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

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
//app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WebApp.Client._Imports).Assembly);

app.UseBlazorFrameworkFiles();

// Authentication and Authorization must happen before mapping the endpoints
app.UseAuthentication();
app.UseAuthorization();


app.UseRouting();
app.UseAntiforgery();
// 1. Map your API Controllers (e.g., /api/wishlist)
app.MapControllers();

// 2. Map Razor Pages (CRITICAL for Identity UI)
// This enables the server to respond to /Identity/Account/Register
app.MapRazorPages();

// 3. Map the Blazor client fallback (everything else goes to the client router)
app.MapFallbackToFile("index.html");

app.Run();
