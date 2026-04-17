
// Connect to postgres
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextPool<RepeatyDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention());

// DI register start
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PublicUserProfileService>();
// DI register end

var app = builder.Build();

// Data seeding
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<RepeatyDbContext>();
    await db.Database.MigrateAsync();
    if (app.Environment.IsDevelopment())
    {
        await DataSeeder.SeedTestDataAsync(db);
    }

}

// Routing 
app.MapGet("/", () => "Health check ok!");
app.MapUserEndpoint();
app.MapUserPublicProfileEndpoint();
app.Run();
