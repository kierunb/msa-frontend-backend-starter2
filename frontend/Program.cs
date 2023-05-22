using frontend;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddHttpClient<WeatherClient>(client =>
{
        // no service discovery
        client.BaseAddress = new Uri("http://localhost:5064");

        //dotnet add frontend/frontend.csproj package Microsoft.Tye.Extensions.Configuration  --version "0.4.0-*"
        client.BaseAddress = builder.Configuration.GetServiceUri("backend");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
