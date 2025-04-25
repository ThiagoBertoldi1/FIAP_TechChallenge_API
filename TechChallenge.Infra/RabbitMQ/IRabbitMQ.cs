namespace TechChallenge.Infra.RabbitMQ;
public interface IRabbitMQ
{
    Task Publish<T>(string queue, T data);
}
