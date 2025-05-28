using Microsoft.EntityFrameworkCore;
using Prescriptions.DAL;
using Prescriptions.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddAuthorization();
builder.Services.AddControllers();

builder.Services.AddScoped<IPrescriptionService, OrmService>();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<PrescriptionsDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.Run();
