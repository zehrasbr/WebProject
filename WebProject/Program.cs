var builder = WebApplication.CreateBuilder(args);

// ? Localization servisi tanýmý
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// ? MVC + view localization
builder.Services.AddControllersWithViews()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();

var app = builder.Build();

// ? Dil desteði kültürleri
var supportedCultures = new[] { "tr", "en" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("tr")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

// Diðer middlewareler
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
