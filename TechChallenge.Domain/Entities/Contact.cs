using TechChallenge.Domain.Entities.Base;

namespace TechChallenge.Domain.Entities;
public class Contact : IEntity
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public long PhoneNumber { get; set; } = 0;
    public string Region { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
}
