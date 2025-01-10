using FluentValidation;
using System.Net;
using TechChallenge.Domain.Entities;
using TechChallenge.Infra.Exceptions;

namespace TechChallenge.Domain.Validations;
public class CreateContactValidation : AbstractValidator<Contact>
{
    public void ContactValidation(Contact contact)
    {
        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Email inválido");

        RuleFor(x => x.PhoneNumber.ToString())
            .NotEmpty().WithMessage("Número de telefone é obrigatório")
            .Matches(@"^\d{2}(9\d{8}|\d{8})$").WithMessage("Número de telefone inválido");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome do contato é obrigatório")
            .MinimumLength(3).WithMessage("Nome do contato precisa ter ao menos 3 caracteres")
            .MaximumLength(255).WithMessage("Nome do contato precisa ter no máximo 255 caracteres");

        var validate = Validate(contact);
        if (!validate.IsValid)
            throw new ApiTechChallengeException(HttpStatusCode.BadRequest, validate.Errors.Select(x => x.ErrorMessage).ToList());
    }
}
