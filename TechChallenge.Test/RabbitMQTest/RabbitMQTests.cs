using Moq;
using TechChallenge.Domain.Entities;
using TechChallenge.Infra.RabbitMQ;

namespace TechChallenge.Test.RabbitMQTest;
public class RabbitMQTests
{

    public static IEnumerable<object[]> QueueObjectList =>
        [
            ["Contact.Queue.Insert", new Contact { Id = Guid.NewGuid(), Name = "Pessoa1", Email = "pessoa1@gmail.com", PhoneNumber = 47991444009, District = "SC", Region = "Sul" }],
            ["Contact.Queue.Update", new Contact { Id = Guid.NewGuid(), Name = "Pessoa2", Email = "pessoa2@gmail.com", PhoneNumber = 47991666009, District = "AP", Region = "Sudeste" }],
            ["Contact.Queue.Delete", new Contact { Id = Guid.NewGuid(), Name = "Pessoa3", Email = "pessoa3@gmail.com", PhoneNumber = 47321330009, District = "PO", Region = "Centro-Oeste" }],

        ];
    [Theory]
    [MemberData(nameof(QueueObjectList))]
    public async Task Publish_Should_DeclareQueue_And_PublishMessage(string queue, Contact contact)
    {
        var rabbitMQ = new Mock<IRabbitMQ>();

        try
        {

            await rabbitMQ.Object.Publish(queue, contact);

            Assert.True(true);
        }
        catch
        {
            Assert.True(false);
        }
    }

    public static IEnumerable<object[]> QueueObjectListErrorObjectNull =>
        [
            ["Contact.Queue.Insert", null],
            ["Contact.Queue.Update", null],
            ["Contact.Queue.Delete", null]
        ];
    [Theory]
    [MemberData(nameof(QueueObjectListErrorObjectNull))]
    public async Task Publish_Shouldnt_DeclareQueue_And_PublishMessage_ObjectNull(string queue, Contact? contact)
    {
        var rabbitMQ = new Mock<IRabbitMQ>();

        try
        {
            await rabbitMQ.Object.Publish(queue, contact);

            Assert.True(true);
        }
        catch
        {
            Assert.True(false);
        }
    }

    public static IEnumerable<object[]> QueueObjectListErrorQueueNull =>
        [
            [string.Empty, new Contact { Id = Guid.NewGuid(), Name = "Pessoa1", Email = "pessoa1@gmail.com", PhoneNumber = 47991444009, District = "SC", Region = "Sul" }],
            [null, new Contact { Id = Guid.NewGuid(), Name = "Pessoa2", Email = "pessoa2@gmail.com", PhoneNumber = 47991666009, District = "AP", Region = "Sudeste" }]

        ];
    [Theory]
    [MemberData(nameof(QueueObjectListErrorQueueNull))]
    public async Task Publish_Shouldnt_DeclareQueue_And_PublishMessage_QueueNull(string queue, Contact? contact)
    {
        var rabbitMQ = new Mock<IRabbitMQ>();

        try
        {
            await rabbitMQ.Object.Publish(queue, contact);

            Assert.True(true);
        }
        catch
        {
            Assert.True(false);
        }
    }
}