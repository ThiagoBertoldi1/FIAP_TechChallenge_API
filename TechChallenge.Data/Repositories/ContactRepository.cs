using Microsoft.Extensions.Configuration;
using TechChallenge.Data.Base;
using TechChallenge.Data.Queries.ContactQueries;
using TechChallenge.Domain.Commands.ContactCommands.Select;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interface;

namespace TechChallenge.Data.Repositories;
public class ContactRepository(IConfiguration configuration) : CrudRepository<Contact>(configuration), IContactRepository
{
    public async Task<Contact?> IsPhoneNumberRegistered(long phoneNumber, CancellationToken cancellationToken)
    {
        var query = new IsPhoneNumberResgisteredQuery(phoneNumber);

        return await RawQueryFirstOrDefaultAsync(query.GetSql(), cancellationToken);
    }

    public async Task<List<Contact>> GetContactList(GetContactListCommand filters, CancellationToken cancellationToken)
    {
        var query = new GetContactListQuery(filters);

        return await RawQueryAsync(query.GetSql(), cancellationToken);
    }
}
