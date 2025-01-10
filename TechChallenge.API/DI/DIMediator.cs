using TechChallenge.Domain.Commands.ContactCommands;

namespace TechChallenge.API.DI;

public static class DIMediator
{
    public static void DIMediatorService(this IServiceCollection service)
    {
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ContactHandler).Assembly));
    }
}
