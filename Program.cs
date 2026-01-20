using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Turnos.API.Data;
using Turnos.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.PropertyNamingPolicy =
            System.Text.Json.JsonNamingPolicy.CamelCase;

    
        opt.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter()
        );
    });

builder.Services.AddDbContext<TurnosDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("DefaultConnection")
        )
    )
);

builder.Services.AddScoped<TurnosService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseMiddleware<Turnos.API.Middlewares.ExceptionMiddleware>();
app.MapControllers();

app.Run();

var connectionString = builder.Configuration["MYSQL_CONNECTION"];

builder.Services.AddDbContext<TurnosDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    )
);





