using Moq;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interface;
using TechChallenge.Domain.Validations;
using TechChallenge.Infra.Exceptions;

namespace TechChallenge.Test.ContactTests;
public class ContactTest
{
    private Mock<IContactRepository> _mockRepository = new();

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

    public static IEnumerable<object[]> InsertContacts =>
        [
            [new Contact { Name = "Pessoa1", Email = "pessoa1@gmail.com", PhoneNumber = 47991444009, District = "SC", Region = "Sul" }],
            [new Contact { Name = "Pessoa2", Email = "pessoa2@gmail.com", PhoneNumber = 47991666009, District = "AP", Region = "Sudeste" }],
            [new Contact { Name = "Pessoa3", Email = "pessoa3@gmail.com", PhoneNumber = 47321330009, District = "PO", Region = "Centro-Oeste" }]
        ];
    [Theory]
    [MemberData(nameof(InsertContacts))]
    public async void Contact_ShouldBeInserted(Contact contact)
    {
        _mockRepository.Setup(x => x.InsertAsync(contact, CancellationToken.None)).ReturnsAsync(true);

        var inserted = await _mockRepository.Object.InsertAsync(contact);

        _mockRepository.Verify(r => r.InsertAsync(contact, CancellationToken.None), Times.Once);
        Assert.True(inserted);
    }

    public static IEnumerable<object[]> UpdateContacts =>
        [
            [new Contact { Id = Guid.NewGuid(), Name = "Pessoa1", Email = "pessoa1@gmail.com", PhoneNumber = 47991444009, District = "SC", Region = "Sul" }],
            [new Contact { Id = Guid.NewGuid(), Name = "Pessoa2", Email = "pessoa2@gmail.com", PhoneNumber = 47991666009, District = "AP", Region = "Sudeste" }],
            [new Contact { Id = Guid.NewGuid(), Name = "Pessoa3", Email = "pessoa3@gmail.com", PhoneNumber = 47321330009, District = "PO", Region = "Centro-Oeste" }]
        ];
    [Theory]
    [MemberData(nameof(UpdateContacts))]
    public async void Contact_ShouldBeUpdated(Contact contact)
    {
        _mockRepository.Setup(x => x.UpdateAsync(contact, CancellationToken.None)).ReturnsAsync(true);

        var response = await _mockRepository.Object.UpdateAsync(contact);

        _mockRepository.Verify(r => r.UpdateAsync(contact, CancellationToken.None), Times.Once);
        Assert.True(response);
    }

    public static IEnumerable<object[]> DeleteContacts =>
        [
            [ Guid.NewGuid() ],
            [ Guid.NewGuid() ],
            [ Guid.NewGuid() ]
        ];
    [Theory]
    [MemberData(nameof(DeleteContacts))]
    public async void Contact_ShouldBeDeleted(Guid id)
    {
        _mockRepository.Setup(x => x.DeleteAsync(id, CancellationToken.None)).ReturnsAsync(true);

        var response = await _mockRepository.Object.DeleteAsync(id);

        _mockRepository.Verify(x => x.DeleteAsync(id, CancellationToken.None), Times.Once);
        Assert.True(response);
    }
}
