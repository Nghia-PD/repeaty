
// Connect to postgres
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextPool<RepeatyPostgresDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention());

// DI register start
builder.Services.AddScoped<PublicUserProfileService>();
// DI register end

var app = builder.Build();
app.MapGet("/", () => "Health check ok!");
app.MapUserPublicProfileEndpoint();
app.Run();
