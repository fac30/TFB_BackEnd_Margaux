using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TFB_BackEnd_Margaux.Data;
using Supabase;
using DotNetEnv;  // Add this at the top to reference DotNetEnv

var builder = WebApplication.CreateBuilder(args);

// Set up the host configuration to load the .env file
builder.Host.ConfigureAppConfiguration((context, config) =>
{
    if (context.HostingEnvironment.IsDevelopment())
    {
        Env.Load("/app/.env");  // Explicitly load .env file from /app directory
    }
});

// Configure Supabase client
var supabaseUrl = Environment.GetEnvironmentVariable("SUPABASE_URL");
var supabaseKey = Environment.GetEnvironmentVariable("SUPABASE_KEY");
var db_host = Environment.GetEnvironmentVariable("DB_HOST");
var db_port = Environment.GetEnvironmentVariable("DB_PORT");
var db_name = Environment.GetEnvironmentVariable("DB_NAME");
var db_user = Environment.GetEnvironmentVariable("DB_USER");
var db_password = Environment.GetEnvironmentVariable("DB_PASSWORD");
var options = new Supabase.SupabaseOptions
{
    AutoConnectRealtime = true
};

builder.Services.AddSingleton<Supabase.Client>(_ => 
    new Supabase.Client(supabaseUrl, supabaseKey, options));

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ClothingItemService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyCloset", Version = "v1" });
});

builder.Services.AddControllers();

var app = builder.Build();

// Initialize the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    DbInitializer.Initialize(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
