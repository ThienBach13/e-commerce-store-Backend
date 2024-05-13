namespace EcomShop.Core.src.Common
{
    public class UserQueryOptions : QueryOptions
    {
        public string? Role { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}