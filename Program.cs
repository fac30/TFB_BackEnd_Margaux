using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Supabase;
using TFB_BackEnd_Margaux.Data;
using TFB_BackEnd_Margaux.Services;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env file
DotNetEnv.Env.Load();

// Log the OpenAI API key for debugging purposes
var openAiApiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

var supabaseUrl = Environment.GetEnvironmentVariable("SUPABASE_URL");
var supabaseKey = Environment.GetEnvironmentVariable("SUPABASE_KEY");
var options = new Supabase.SupabaseOptions { AutoConnectRealtime = true };

builder.Services.AddSingleton<Supabase.Client>(_ => new Supabase.Client(
    supabaseUrl,
    supabaseKey,
    options
));

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<ClothingItemService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyCloset", Version = "v1" });
});

builder.Services.AddControllers();

// Configure HttpClient for OpenAI
builder.Services.AddHttpClient(
    "OpenAI",
    client =>
    {
        client.BaseAddress = new Uri("https://api.openai.com/v1/");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Bearer",
            Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );
    }
);

// Add OpenAI services
builder.Services.AddScoped<IOpenAiService, OpenAiService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowSpecific",
        builder =>
        {
            builder
                .WithOrigins(
                    "http://localhost:5174" // Your specified origin
                )
                .AllowAnyMethod()
                .AllowAnyHeader();
        }
    );
});

var app = builder.Build();
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

app.UseCors("AllowSpecific");
app.UseAuthorization();
app.MapControllers();
app.Run();

namespace TFB_BackEnd_Margaux.Services
{
    // Class definition
}
