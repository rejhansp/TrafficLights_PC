using PolarC_task.Mappers;
using PolarC_task.SignalR;
using PolarC_task.TrafficLight.Factory;
using PolarC_task.TrafficLight.Hubs;
using PolarC_task.Workers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ITrafficLightFactory, TrafficLightFactory>();
builder.Services.AddSingleton<ITrafficLightCustomMapper, TrafficLightCustomMapper>();

builder.Services.AddHostedService<TrafficLightWorker>();

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader().
           AllowAnyMethod()
           .WithOrigins("https://localhost:44491")
           .AllowCredentials();

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseStaticFiles();

app.UseCors("ClientPermission");

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapHub<TrafficLightStatusHub>("/hubs/chat");

app.MapFallbackToFile("index.html"); ;

app.Run();
