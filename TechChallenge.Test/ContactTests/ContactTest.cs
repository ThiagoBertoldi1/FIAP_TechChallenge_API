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
        var exception = Record.Exception(() => new ContactValidation().ContactValidator(contact));

        Assert.Null(exception);
    }

    public static IEnumerable<object[]> ValidRegions =>
        [
            [new Contact { Region = "Sul" }],
            [new Contact { Region = "Sudeste" }],
            [new Contact { Region = "Norte" }],
        ];
    [Theory]
    [MemberData(nameof(ValidRegions))]
    public void Regions_ShouldBeValid(Contact contact)
    {
        Assert.True(!string.IsNullOrEmpty(contact.Region));
    }

    public static IEnumerable<object[]> InvalidRegions =>
        [
            [new Contact { Region = "" }],
            [new Contact { Region = string.Empty }],
            [new Contact { Region = null }],
        ];
    [Theory]
    [MemberData(nameof(InvalidRegions))]
    public void Regions_ShouldntBeValid(Contact contact)
    {
        Assert.True(string.IsNullOrEmpty(contact.Region));
    }

    public static IEnumerable<object[]> ValidDistrict =>
        [
            [new Contact { District = "SC" }],
            [new Contact { District = "PR" }],
            [new Contact { District = "SP" }],
        ];
    [Theory]
    [MemberData(nameof(ValidDistrict))]
    public void District_ShouldBeValid(Contact contact)
    {
        Assert.True(string.IsNullOrEmpty(contact.Region));
    }

    public static IEnumerable<object[]> InvalidDistrict =>
        [
            [new Contact { District = "" }],
            [new Contact { District = string.Empty }],
            [new Contact { District = null }],
        ];
    [Theory]
    [MemberData(nameof(InvalidDistrict))]
    public void District_ShouldntBeValid(Contact contact)
    {
        Assert.True(string.IsNullOrEmpty(contact.Region));
    }
}