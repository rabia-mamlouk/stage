using API.Extension;
using Application.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Npgsql; // Required for database creation logic
using Persistance.Data;   // Your DbContext namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration = builder.Configuration;

builder.Services.ConfigureContext(configuration);
builder.Services.AddControllers();
builder.Services.RetryExtension(configuration);
builder.Services.AddMemoryCache();
builder.Services.AddSignalR();
builder.Services.AddCors(options => options.AddPolicy("cors", builder =>
{
    builder
    .WithOrigins("http://localhost:4200", "https://ftusa-web.dev2.addinn-group.com")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials();
}));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.ConfigureSwagger();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// ✅ Ensure database exists and run migrations
using (var scope = app.Services.CreateScope())
{
    var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();

    var host = config["PG_HOST"];
    var dbName = config["PG_DATABASE"];
    var username = config["PG_USERNAME"];
    var password = config["PG_PASSWORD"];

    // 1️⃣ Connect to the default "postgres" DB
    var masterConnStr = $"Host={host};Database=postgres;Username={username};Password={password}";
    using (var conn = new NpgsqlConnection(masterConnStr))
    {
        conn.Open();
        using (var cmd = new NpgsqlCommand($"SELECT 1 FROM pg_database WHERE datname = '{dbName}'", conn))
        {
            var exists = cmd.ExecuteScalar();
            if (exists == null)
            {
                using var createCmd = new NpgsqlCommand($"CREATE DATABASE \"{dbName}\"", conn);
                createCmd.ExecuteNonQuery();
                Console.WriteLine($"✅ Database {dbName} created.");
            }
            else
            {
                Console.WriteLine($"ℹ️ Database {dbName} already exists.");
            }
        }
    }

    // 2️⃣ Run EF Core migrations
    var db = scope.ServiceProvider.GetRequiredService<DematContext>();
    db.Database.Migrate();
}

app.UseRouting();

// Configure the HTTP request pipeline.
app.UseCors("cors");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
