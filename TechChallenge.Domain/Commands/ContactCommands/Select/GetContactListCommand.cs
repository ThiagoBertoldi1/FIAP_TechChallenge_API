using MediatR;
using TechChallenge.Domain.Entities;
using TechChallenge.Infra.Responses;

namespace TechChallenge.Domain.Commands.ContactCommands.Select;
public class GetContactListCommand : IRequest<ResponseBase<List<Contact>>>
{
    public int Page { get; set; } = 1;
    public int ItemsPerPage { get; set; } = 10;
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public long? PhoneNumber { get; set; }
    public string? Region { get; set; }
    public string? District { get; set; }
    public int? DDD { get; set; }
}
