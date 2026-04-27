
// Connect to postgres
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;

// Firebase
FirebaseApp.Create(new AppOptions
{
    Credential = GoogleCredential.FromAccessToken("test"),
    ProjectId = "repeaty-io"
});

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
