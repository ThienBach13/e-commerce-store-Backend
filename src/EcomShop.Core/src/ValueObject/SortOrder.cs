using System.Text.Json.Serialization;

namespace EcomShop.Core.src.ValueObject
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SortOrder
    {
        Ascending,
        Descending
    }
}