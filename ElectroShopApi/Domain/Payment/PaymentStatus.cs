using System.Text.Json.Serialization;

namespace ElectroShopApi.Domain.Payment
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentStatus
    {
        Success,
        Failure,
        Progress
    }
}
