using BlazorGourmet.Client.Components;
using BlazorGourmet.Client.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add services to the container.
builder.Services.AddRazorComponents();

builder.Services.AddHttpClient("MealDbClient", client =>
{
    client.BaseAddress = new Uri("https://www.themealdb.com/api/json/v1/1/");
});

builder.Services.AddMemoryCache();
builder.Services.AddScoped<IMealDbService, MealDbService>();
builder.Services.AddScoped<CachedMemberService>();
//builder.Services.AddTransient<IMealDbService, MealDbService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
