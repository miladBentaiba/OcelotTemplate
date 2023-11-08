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
    c.SwaggerDoc("attendance", new OpenApiInfo { Title = "Attendance API"});
    c.SwaggerDoc("admission", new OpenApiInfo { Title = "Admission API"});

    // Add other microservice Swagger documents here.
});

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);


var app = builder.Build();

app.UseStaticFiles();

app.MapControllers();

app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
});

app.UseOcelot().Wait();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/attendance/swagger.json", "attendance");
        c.SwaggerEndpoint("/swagger/admission/swagger.json", "admission");

        // Add other microservice Swagger endpoints here.
    });
}

app.Run();
