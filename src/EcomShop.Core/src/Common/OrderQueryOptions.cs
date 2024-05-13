namespace EcomShop.Core.src.Common
{
    public class OrderQueryOptions : QueryOptions
    {
        public int? UserId { get; set; }
        public DateTimeOffset? From { get; set; }
        public DateTimeOffset? To { get; set; }
        public int? AddressId { get; set; }
    }
}