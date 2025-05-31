using Blazored.Toast;
using Microsoft.EntityFrameworkCore;
using RegistrosTenicos.Components;
using RegistrosTenicos.DAL;
using RegistrosTenicos.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Obtenemos el ConStr para usarlo en el contexto
var ConStr = builder.Configuration.GetConnectionString("NpgsqlConStr");

// Agremos el contexto al builder con el ConStr
builder.Services.AddDbContextFactory<Contexto>(o => o.UseNpgsql(ConStr));


// Inyeccion del service
builder.Services.AddScoped<TecnicosServices>();
builder.Services.AddScoped<ClientesServices>();
builder.Services.AddBlazoredToast();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
