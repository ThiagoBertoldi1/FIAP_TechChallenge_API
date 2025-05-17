using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Validations;
using TechChallenge.Infra.Exceptions;

namespace TechChallenge.Test.ContactTests;
public class ContactTest
{
    public static IEnumerable<object[]> InvalidContacts =>
        [
            [new Contact { Name = "Pessoa1", Email = "pessoa1", PhoneNumber = 47991598535 }],
            [new Contact { Name = "Pessoa2", Email = "pessoa2@gmail.com", PhoneNumber = 4799133 }],
            [new Contact { Name = "Pe", Email = "pessoa3@gmail.com", PhoneNumber = 4799133 }]
        ];
    [Theory]
    [MemberData(nameof(InvalidContacts))]
    public void Contact_ShouldBeInvalid_And_ThrowApiTechChallengeException(Contact contact)
    {
        var validator = new ContactValidation();

        Assert.Throws<ApiTechChallengeException>(() => validator.ContactValidator(contact));
    }

    public static IEnumerable<object[]> ValidContacts =>
        [
            [new Contact { Name = "Pessoa1", Email = "pessoa1@hotmail.com", PhoneNumber = 47991598535 }],
            [new Contact { Name = "Pessoa2", Email = "pessoa2@gmail.com", PhoneNumber = 47991330009 }],
            [new Contact { Name = "Pessoa3", Email = "pessoa3@gmail.com", PhoneNumber = 47991330009 }]
        ];
    [Theory]
    [MemberData(nameof(ValidContacts))]
    public void Contact_ShouldBeValid(Contact contact)
    {
        try
        {
            new ContactValidation().ContactValidator(contact);
            Assert.True(true);
        }
        catch
        {
            Assert.True(false);
        }
    }
}
