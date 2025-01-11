using MediatR;
using TechChallenge.Infra.Responses;

namespace TechChallenge.Domain.Commands.ContactCommands.Update;
public class UpdateContactCommand : IRequest<ResponseBase<string>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public long PhoneNumber { get; set; } = default;
}