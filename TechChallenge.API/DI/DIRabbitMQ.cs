using TechChallenge.Infra.RabbitMQ;

namespace TechChallenge.API.DI;

public static class DIRabbitMQ
{
    public static void DIRabbitMQService(this IServiceCollection services)
    {
        services.AddSingleton<IRabbitMQ, RabbitMQService>();
    }
}
