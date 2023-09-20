using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IConnectionMultiplexer>(x =>
{
    var redisOptions = builder.Configuration.GetSection("RedisOptions");
    var connectionString = redisOptions.GetValue<string>("ConnectionString");
    var instanceName = redisOptions.GetValue<string>("InstanceName");

    var configuration = new ConfigurationOptions
    {
        EndPoints = { connectionString },
        ClientName = instanceName,
        AbortOnConnectFail = false // Ajusta según tus necesidades
    };

    return ConnectionMultiplexer.Connect(configuration);
});
var app = builder.Build();
// Configura la conexión Redis
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
