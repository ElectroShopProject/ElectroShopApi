using System.Text.Json.Serialization;

namespace ElectroShop
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProductCategory
    {
        Ebook,
        Storage,
        Others
    }
}
