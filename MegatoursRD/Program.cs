using MegatoursRD.Components;
using MegatoursRD.Components.Account;
using MegatoursRD.Data;
using MegatoursRD.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<AdminsService>();
builder.Services.AddScoped<ClientesServices>();
builder.Services.AddScoped<SolicitudViajesService>();
builder.Services.AddScoped<DestinosService>();
builder.Services.AddScoped<ViajesService>();
builder.Services.AddScoped<SolicitudViajesDetalleService>();
builder.Services.AddScoped<GuiasService>();
builder.Services.AddScoped<CarritoService>();
builder.Services.AddBlazorBootstrap();

// Carrito anonimo
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();


builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContextFactory<ApplicationDbContext>(o =>
    o.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
	options.SignIn.RequireConfirmedAccount = true;
})
	.AddRoles<IdentityRole>()  // <-- IMPORTANTE
	.AddEntityFrameworkStores<ApplicationDbContext>()  // <-- Esto le dice a Identity dónde guardar datos
	.AddSignInManager()
	.AddUserManager<UserManager<ApplicationUser>>()  // <-- Asegura que UserManager está registrado
	.AddRoleManager<RoleManager<IdentityRole>>()  // <-- Asegura que RoleManager está registrado
	.AddDefaultTokenProviders();


builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Carrito anonimo
app.UseSession();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
