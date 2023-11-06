using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Ocelot.Values;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot();

builder.Services.AddSwaggerForOcelot(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API",
        Contact = new OpenApiContact
        {
            Name = "Microservice1: Student Admission",
            Url = new Uri("https://localhost:7018/swagger/index.html")
        },
        License = new OpenApiLicense
        {
            Name = "Microservice2: Student Attendance",
            Url = new Uri("https://localhost:7264/swagger/index.html")
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("v1/swagger.json", "Main");
        c.SwaggerEndpoint("v1/swagger.json", "My API V1");
    });
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseOcelot().Wait();

app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
});

app.Run();
