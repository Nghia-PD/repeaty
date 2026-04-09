
// Connect to postgres
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextPool<RepeatyPostgresDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.MapGet("/", () => "Health check ok!");
app.MapUserPublicProfileEndpoint();
app.Run();
