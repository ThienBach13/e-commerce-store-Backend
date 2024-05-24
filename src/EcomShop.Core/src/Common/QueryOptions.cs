using System.Text.Json.Serialization;
using EcomShop.Core.src.ValueObject;

namespace EcomShop.Core.src.Common
{
    public class QueryOptions
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SortOrder SortOrder { get; set; } = SortOrder.Ascending;
        public QueryOptions()
        {
            // Set default values for Page and PageSize
            Page = 1;
            PageSize = 10;
        }
    }
}