using Prometheus;
using System.Diagnostics;

public class CpuMetricsCollector
{
    private readonly Gauge _cpuUsageGauge = Metrics.CreateGauge("cpu_usage_percentage", "Uso de CPU (%)");

    public void StartMonitoring()
    {
        Task.Run(async () =>
        {
            var process = Process.GetCurrentProcess();
            var prevCpuTime = process.TotalProcessorTime;
            var prevTimestamp = DateTime.UtcNow;

            while (true)
            {
                await Task.Delay(1000);

                process.Refresh();
                var cpuTime = process.TotalProcessorTime;
                var now = DateTime.UtcNow;

                var elapsedCpuTime = (cpuTime - prevCpuTime).TotalMilliseconds;
                var elapsedTime = (now - prevTimestamp).TotalMilliseconds;

                prevCpuTime = cpuTime;
                prevTimestamp = now;

                double cpuUsage = 100 * (elapsedCpuTime / elapsedTime);
                _cpuUsageGauge.Set(cpuUsage);
            }
        });
    }
}