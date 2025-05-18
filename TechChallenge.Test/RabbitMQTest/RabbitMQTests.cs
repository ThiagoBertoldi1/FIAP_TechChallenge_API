using Moq;
using TechChallenge.Domain.Entities;
using TechChallenge.Infra.Helpers.ValidQueuePublish;
using TechChallenge.Infra.RabbitMQ;

namespace TechChallenge.Test.RabbitMQTest;
public class RabbitMQTests
{
    public static IEnumerable<object[]> QueueObjectList =>
        [
            ["Contact.Queue.Insert", new Contact { Id = Guid.NewGuid(), Name = "Pessoa1", Email = "pessoa1@gmail.com", PhoneNumber = 47991444009, District = "SC", Region = "Sul" }],
            ["Contact.Queue.Update", new Contact { Id = Guid.NewGuid(), Name = "Pessoa2", Email = "pessoa2@gmail.com", PhoneNumber = 47991666009, District = "AP", Region = "Sudeste" }],
            ["Contact.Queue.Delete", new Contact { Id = Guid.NewGuid(), Name = "Pessoa3", Email = "pessoa3@gmail.com", PhoneNumber = 47321330009, District = "PO", Region = "Centro-Oeste" }]
        ];
    [Theory]
    [MemberData(nameof(QueueObjectList))]
    public async Task Publish_Should_DeclareQueue_And_PublishMessage(string queue, Contact contact)
    {
        var mockRabbit = new Mock<IRabbitMQ>();

        await mockRabbit.Object.Publish(queue, contact);

        mockRabbit.Verify(p => p.Publish(queue,
            It.Is<Contact>(c => c.Id == contact.Id)), Times.Once);
    }

    public static IEnumerable<object[]> QueueValid =>
        [
            ["Contact.Queue.Insert"],
            ["Contact.Queue.Update"],
            ["Contact.Queue.Delete"]
        ];
    [Theory]
    [MemberData(nameof(QueueValid))]
    public void Publish_Should_QueueBeValid(string queue)
    {
        Assert.True(QueuePublishValidation.Validation(queue));
    }

    public static IEnumerable<object[]> QueueInvalid =>
        [
            [string.Empty],
            [null],
            [""]
        ];
    [Theory]
    [MemberData(nameof(QueueInvalid))]
    public void Publish_Should_QueueBeInvalid(string? queue)
    {
        Assert.False(QueuePublishValidation.Validation(queue));
    }

    [Fact]
    public void Publish_Should_DataBeValid()
    {
        var contact = new Contact { Id = Guid.NewGuid() };

        Assert.True(QueuePublishValidation.Validation(contact));
    }

    [Fact]
    public void Publish_Should_DataBeInvalid()
    {
        Contact? contact = null;

        Assert.False(QueuePublishValidation.Validation(contact));
    }

    public static IEnumerable<object[]> QueueAndDataValid =>
       [
            ["Contact.Queue.Insert", new Contact() { Id = Guid.NewGuid() }],
            ["Contact.Queue.Update", new Contact() { Id = Guid.NewGuid() }],
            ["Contact.Queue.Delete", new Contact() { Id = Guid.NewGuid() }]
       ];
    [Theory]
    [MemberData(nameof(QueueAndDataValid))]
    public void Publish_Should_DataAndQueueBeValid(string queue, Contact contact)
    {
        Assert.True(QueuePublishValidation.Validation(queue, contact));
    }

    public static IEnumerable<object[]> QueueOrDataInvalid =>
       [
            [string.Empty, null],
            ["Contact.Queue.Insert", null],
            [null, new Contact() { Id = Guid.NewGuid() }]
       ];
    [Theory]
    [MemberData(nameof(QueueOrDataInvalid))]
    public void Publish_Should_DataOrQueueBeInvalid(string? queue, Contact? contact)
    {
        Assert.False(QueuePublishValidation.Validation(queue, contact));
    }
}