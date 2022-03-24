using System;
namespace ElectroShopApi.Domain.User
{

    public record User(string Name)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}