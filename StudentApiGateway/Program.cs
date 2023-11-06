using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot();

builder.Services.AddSwaggerForOcelot(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("attendance", new OpenApiInfo { Title = "Attendance API", Version = "v1" });
    c.SwaggerDoc("admission", new OpenApiInfo { Title = "Admission API", Version = "v1" });

    // Add other microservice Swagger documents here.
});

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);


var app = builder.Build();

app.UsePathBase("/gateway");
app.UseStaticFiles();
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("https://localhost:7264/swagger/v1/swagger.json", "Attendance API");
        c.SwaggerEndpoint("https://localhost:7018/swagger/v1/swagger.json", "Admission API");

        // Add other microservice Swagger endpoints here.
    });
}



app.MapControllers();



app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
});

app.UseOcelot().Wait(); 

app.UseRouting();
app.Run();
