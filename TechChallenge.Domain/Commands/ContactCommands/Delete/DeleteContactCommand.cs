using MediatR;
using TechChallenge.Infra.Responses;

namespace TechChallenge.Domain.Commands.ContactCommands.Delete;
public class DeleteContactCommand : IRequest<ResponseBase<string>>
{
    public Guid Id { get; set; }
}
