namespace TechChallenge.API.DI;

public static class DIMemoryCache
{
    public static void DIMemoryCacheService(this IServiceCollection service)
    {
        service.AddMemoryCache(options => { options.ExpirationScanFrequency = TimeSpan.FromMinutes(1); });
    }
}
