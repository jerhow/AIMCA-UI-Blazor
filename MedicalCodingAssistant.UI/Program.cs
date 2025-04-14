using MedicalCodingAssistant.UI.Components;
using MedicalCodingAssistant.UI.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// Binds the ApiSettings class to your config to make it available for dependency injection
// and to be used in your components.
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

// Adds a named HttpClient for the Medical Coding API with the base URL and authorization header that we can inject elsewhere.
builder.Services.AddHttpClient("MedicalCodingAPI", (serviceProvider, client) =>
{
    var config = serviceProvider.GetRequiredService<IConfiguration>();
    var settings = config.GetSection("ApiSettings").Get<ApiSettings>();

    client.BaseAddress = new Uri(settings.ApiBaseUrl);
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {settings.ApiKey}");
});

// Load user secrets conditionally based on the environment.
// This should happen automatically in development, but this ensures it explicitly.
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

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

// app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
