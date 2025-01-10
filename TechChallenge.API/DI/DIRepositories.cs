using TechChallenge.Data.Base;
using TechChallenge.Data.Repositories;
using TechChallenge.Domain.Entities.Base;
using TechChallenge.Domain.Interface;
using TechChallenge.Domain.Interface.BaseRepository;

namespace TechChallenge.API.DI;

public static class DIRepositories
{
    public static void DIRepositoriesService(this IServiceCollection service)
    {
        service.AddTransient<ICrudRepository<IEntity>, CrudRepository<IEntity>>();
        service.AddTransient<IContactRepository, ContactRepository>();
    }
}
