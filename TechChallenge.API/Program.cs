using Prometheus;
using TechChallenge.API.DI;
using TechChallenge.API.Middlewares;

new CpuMetricsCollector().StartMonitoring();

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.DIRepositoriesService();
builder.Services.DIMediatorService();
builder.Services.DIMemoryCacheService();
builder.Services.DIRabbitMQService();
builder.Services.AddMetrics();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(3000);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapMetrics();
app.UseMiddleware<ApiErrorMiddleware>();
app.UseMiddleware<PrometheusMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
