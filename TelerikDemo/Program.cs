using CommonLib;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;
using Telerik.Blazor.Services;
using TelerikDemo;
using TelerikDemo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTelerikBlazor();
builder.Services.AddCommonLibService();
builder.Services.AddSingleton(typeof(ITelerikStringLocalizer), typeof(SampleResxLocalizer));
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    // define the list of cultures your app will support
    var supportedCultures = new List<CultureInfo>()
            {
                new CultureInfo("zh-CN"),
                new CultureInfo("de-DE"),
                new CultureInfo("es-ES"),
                new CultureInfo("bg-BG")
            };

    // set the default culture
    options.DefaultRequestCulture = new RequestCulture("zh-CN");

    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});
var app = builder.Build();
//app.UseRequestLocalization(app.Services.GetService<IOptions<RequestLocalizationOptions>>().Value);
app.UseRequestLocalization("zh-CN");
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
