using Prometheus;
using System.Diagnostics;
using TechChallenge.API.DI;
using TechChallenge.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.DIRepositoriesService();
builder.Services.DIMediatorService();
builder.Services.DIMemoryCacheService();
builder.Services.AddMetrics();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Métrica de uso de memória
var memoryGauge = Metrics.CreateGauge("api_memory_usage_bytes", "Uso de memória da API em bytes");

// Métrica de uso de CPU
var cpuGauge = Metrics.CreateGauge("api_cpu_usage_seconds", "Tempo total de CPU usado pela API");

// Contador de requisições
var requestCounter = Metrics.CreateCounter("api_request_count", "Número total de requisições recebidas");

app.Use(async (context, next) =>
{
    // Atualiza a memória usada
    memoryGauge.Set(GC.GetTotalMemory(false));

    // Atualiza o tempo de CPU usado
    var cpuUsage = Process.GetCurrentProcess().TotalProcessorTime.TotalSeconds;
    cpuGauge.Set(cpuUsage);

    // Incrementa o contador de requisições
    requestCounter.Inc();

    await next();
});

app.MapMetrics();
app.UseMiddleware<ApiErrorMiddleware>();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
