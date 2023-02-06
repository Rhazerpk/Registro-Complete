using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Registro.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var ConStr = builder.Configuration.GetConnectionString("ConStr");

IServiceCollection serviceCollection = builder.Services.AddDbContext<Contexto>(options => options.UseSqlite(ConStr));
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<OcupacionesBLL>();
builder.Services.AddScoped<PersonasBLL>();
builder.Services.AddScoped<PrestamosBLL>();
builder.Services.AddScoped<PagosBLL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();