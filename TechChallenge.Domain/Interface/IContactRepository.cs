using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interface.BaseRepository;

namespace TechChallenge.Domain.Interface;
public interface IContactRepository : ICrudRepository<Contact>
{
    Task<Contact?> IsPhoneNumberRegistered(long phoneNumber, CancellationToken cancellationToken);
}
