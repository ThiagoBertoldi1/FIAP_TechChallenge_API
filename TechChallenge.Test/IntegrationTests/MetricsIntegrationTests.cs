using FluentAssertions;
using System.Net;

namespace TechChallenge.Test.IntegrationTests;
public class MetricsIntegrationTests
{
    private readonly HttpClient _client = new() { BaseAddress = new Uri("http://dotnet-api:80") };
    [Fact]
    public async Task MetricsEndpoint_ShouldReturn_Success_And_Contain_Metric_Api_Request_Count()
    {
        var response = await _client.GetAsync("/metrics");
        var content = await response.Content.ReadAsStringAsync();

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        content.Should().Contain("api_request_count");
    }

    [Fact]
    public async Task MetricsEndpoint_ShouldReturn_Success_And_Contain_Metric_CPU_Usage_Percentage()
    {
        var response = await _client.GetAsync("/metrics");
        var content = await response.Content.ReadAsStringAsync();

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        content.Should().Contain("cpu_usage_percentage");
    }

    [Fact]
    public async Task MetricsEndpoint_ShouldReturn_Success_And_Contain_Metric_Api_Memory_Usage_Bytes()
    {
        var response = await _client.GetAsync("/metrics");
        var content = await response.Content.ReadAsStringAsync();

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        content.Should().Contain("api_memory_usage_bytes");
    }

    [Fact]
    public async Task MetricsEndpoint_ShouldReturn_Success_And_Contain_Metric_Microsoft_Aspnetcore_Hosting_Http_Server_Request_Duration_Bucket()
    {
        var response = await _client.GetAsync("/metrics");
        var content = await response.Content.ReadAsStringAsync();

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        content.Should().Contain("microsoft_aspnetcore_hosting_http_server_request_duration_bucket");
    }
}