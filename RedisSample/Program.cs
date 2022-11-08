using RedisSample.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration = builder.Configuration;
var multiplexer = ConnectionMultiplexer.Connect("localhost");
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);
builder.Services.AddSingleton<ICacheService, CacheService>();
builder.Services.AddSingleton<ICategoryService, CategoryService>();

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

app.Run();
