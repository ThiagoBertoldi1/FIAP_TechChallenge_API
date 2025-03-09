using Prometheus;

namespace TechChallenge.API.Middlewares;

public class PrometheusMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    private readonly Gauge _memoryGauge = Metrics.CreateGauge("api_memory_usage_bytes", "Uso de memória da API em bytes");
    private readonly Counter _requestCounter = Metrics.CreateCounter("api_request_count", "Número total de requisições recebidas");

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            GetMetricsPrometheus();

            await _next(context);
        }
        catch
        {
            throw;
        }
    }

    public void GetMetricsPrometheus()
    {
        _memoryGauge.Set(GC.GetTotalMemory(false) / (1024.0 * 1024.0));
        _requestCounter.Inc();
    }
}
