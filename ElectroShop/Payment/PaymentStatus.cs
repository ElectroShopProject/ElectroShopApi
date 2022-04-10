using System.Text.Json.Serialization;

namespace ElectroShop
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentStatus
    {
        Success,
        Failure,
        Progress
    }
}
