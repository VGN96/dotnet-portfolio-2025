using Microsoft.EntityFrameworkCore;
using MyEcommerceAPI.Data;    // adjust namespace if different
using Microsoft.OpenApi;
using Application.Interfaces;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// --- Services ---
builder.Services.AddControllers();

// Register AppDbContext using InMemory (easy for dev/testing)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("MyEcomDb"));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IDateTimeService, DateTimeService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyEcommerceAPI", Version = "v1" });
});

var app = builder.Build();

// --- Middleware ---
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyEcommerceAPI v1"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
