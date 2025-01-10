using MediatR;
using TechChallenge.Domain.Entities;
using TechChallenge.Infra.Responses;

namespace TechChallenge.Domain.Commands.ContactCommands.Create;
public class CreateContactCommand : IRequest<ResponseBase<Contact>>
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public long PhoneNumber { get; set; } = default;
}
