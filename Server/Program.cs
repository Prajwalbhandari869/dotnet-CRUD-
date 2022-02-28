using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using SongsTrack.Repository.Data;
using SongsTrack.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/// <summary>
/// This registers a DbContext subclass called DataContect as a 
/// service provider. The DataContext is configured to use the SQL Server database provider 
/// and will read the connection string from appsettings.Development.json.
/// </summary>
builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

/// <summary>
/// AddApplicationServices is an extensoin service of IServiceCollection which provide configurations for DI. 
/// </summary>
builder.Services.AddApplicationServices();

/// <summary>
/// This is used to support controller. It also support views but do not support pages within the server application.
/// </summary>
builder.Services.AddControllersWithViews();

/// <summary>
/// This support both views as well as pages.
/// </summary>
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
/// <summary>
/// It is a middleware that redirect HTTP requests to HTTPS
/// This issue HTTP response codes redirecting from http to https.
/// </summary>
app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

/// <summary>
/// It is a middleware which is used to match request to an endpoints.
/// </summary>
app.UseRouting();

app.MapRazorPages();

/// <summary>
/// It maps controller method as baseAddress/api/ControllerName/HTTPRequest.
/// </summary>
app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();
