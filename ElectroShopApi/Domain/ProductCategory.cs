using System;
using System.Text.Json.Serialization;

namespace ElectroShopApi
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProductCategory
    {
        Telecommunication,
        Computers,
        Others
    }
}
