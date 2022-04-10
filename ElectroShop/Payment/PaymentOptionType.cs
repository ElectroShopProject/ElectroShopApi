using System.Text.Json.Serialization;

namespace ElectroShop
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentOptionType
    {
        CreditCard,
        BankTransfer,
        PayPal,
        Cash
    }
}
