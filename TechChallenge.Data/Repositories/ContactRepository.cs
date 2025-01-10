using Microsoft.Extensions.Configuration;
using TechChallenge.Data.Base;
using TechChallenge.Data.Queries.ContactQueries;
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
}
