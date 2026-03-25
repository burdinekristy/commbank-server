using CommBank_Server.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// 1. Configure MongoDB Connection
// This reads from the "MongoDB" section in your appsettings.json
var mongoConnectionString = builder.Configuration.GetSection("MongoDB")["ConnectionString"];
var mongoDatabaseName = builder.Configuration.GetSection("MongoDB")["DatabaseName"];

if (string.IsNullOrEmpty(mongoConnectionString) || string.IsNullOrEmpty(mongoDatabaseName))
{
    throw new Exception("MongoDB ConnectionString or DatabaseName is missing in appsettings.json");
}

var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase(mongoDatabaseName);

// 2. Register Services for Dependency Injection
builder.Services.AddSingleton(mongoDatabase);
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IGoalsService, GoalsService>();
builder.Services.AddScoped<IUsersService, UsersService>();

// 3. Add Standard API Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. Configure the HTTP Request Pipeline
if (app.Environment.IsDevelopment())
{
    // Enables the Swagger UI for testing at /swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
