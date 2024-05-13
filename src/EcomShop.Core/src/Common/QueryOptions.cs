namespace EcomShop.Core.src.Common
{
    public class QueryOptions
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public string SearchKey { get; set; } = string.Empty;
    }
}