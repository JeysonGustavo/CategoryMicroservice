using Category.API.Core.EventBus;
using Category.API.Core.Infrastructure;
using Category.API.Core.Manager;
using Category.API.Infrastructure.DAL;
using Category.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<ICategoryDAL, CategoryDAL>();
builder.Services.AddSingleton<IEventBusMessage, EventBusMessage>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var connection = builder.Configuration.GetConnectionString("CategoryConn");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connection));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

//InitializeDb.Initialize(app);

app.Run();
