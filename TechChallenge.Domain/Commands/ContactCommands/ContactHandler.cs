using MediatR;
using System.Net;
using TechChallenge.Domain.Commands.ContactCommands.Create;
using TechChallenge.Domain.Commands.ContactCommands.Select;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interface;
using TechChallenge.Domain.Validations;
using TechChallenge.Infra.Helpers.DDD;
using TechChallenge.Infra.Responses;

namespace TechChallenge.Domain.Commands.ContactCommands;
public class ContactHandler(IContactRepository contactRepository) :
    IRequestHandler<CreateContactCommand, ResponseBase<Contact>>,
    IRequestHandler<GetContactListCommand, ResponseBase<List<Contact>>>
{
    private readonly IContactRepository _contactRepository = contactRepository;

    public async Task<ResponseBase<Contact>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var entity = new Contact
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber
        };

        new CreateContactValidation().ContactValidation(entity);

        var exists = await _contactRepository.IsPhoneNumberRegistered(entity.PhoneNumber, cancellationToken);
        if (exists is not null)
            return ResponseBase<Contact>.Fault(HttpStatusCode.BadRequest, ["Número de telefone já cadastrado"]);

        var (region, district) = await new GetDDDHelper().GetDDDInfo(int.Parse(request.PhoneNumber.ToString()[..2]));

        entity.District = district;
        entity.Region = region;

        var inserted = await _contactRepository.InsertAsync(entity, cancellationToken);
        if (inserted != 1)
            return ResponseBase<Contact>.Fault(HttpStatusCode.InternalServerError, ["Usuário não inserido"]);

        return ResponseBase<Contact>.Create(entity);
    }

    public async Task<ResponseBase<List<Contact>>> Handle(GetContactListCommand filters, CancellationToken cancellationToken)
    {
        var response = await _contactRepository.GetContactList(filters, cancellationToken);

        return ResponseBase<List<Contact>>.Create(response);
    }
}
