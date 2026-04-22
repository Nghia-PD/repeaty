
// Connect to postgres
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextPool<RepeatyDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention());

// DI register start
builder.Services.AddScoped<UserService>();
// DI register end

var app = builder.Build();


// Routing 
app.MapGet("/", () => "Health check ok!");
app.MapUserEndpoint();
app.Run();
