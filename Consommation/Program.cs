using Consommation.Database;
using Consommation.Database.Managers;
using Consommation.Domain.Business;
using Consommation.Domain.Interfaces.Business;
using Consommation.Domain.Interfaces.Manager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<ICommentaireManager, CommentaireManager>();
builder.Services.AddScoped<ICommentaireBusiness, CommentaireBusiness>();
builder.Services.AddScoped<ITrajetManager, TrajetManager>();
builder.Services.AddScoped<ITrajetBusiness, TrajetBusiness>();
builder.Services.AddScoped<IVoitureManager, VoitureManager>();
builder.Services.AddScoped<IVoitureBusiness, VoitureBusiness>();
builder.Services.AddScoped<IRechargeManager, RechargeManager>();
builder.Services.AddScoped<IRechargeBusiness, RechargeBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
