using EcomShop.Core.src.Entity;

namespace EcomShop.Core.src.RepoAbstract
{
    public interface IReviewRepo
    {
        // --function to insert reviews to database
        Task<Review> CreateReviewAsync(Review review);
        // -- function get all reviews 
        Task<IEnumerable<Review>> GetAllReviwesAsync();
        // -- function to get all review by customer ID
        Task<IEnumerable<Review>> GetAllReviwesByCustomerIdAsync(int userId);
        // -- function to get all review by product ID
        Task<IEnumerable<Review>> GetAllReviwesByProductIdAsync(int productId);
        // -- function to get all review by order ID
        Task<IEnumerable<Review>> GetAllReviwesByOrderIdAsync(int orderId);
        // -- function to get a review by customer ID and product ID
        Task<Review> GetReviewByCustomerIdAndProductIdAsync(int customerId, int productId);
        // -- function to update 1 review by using customer_id and product_id
        Task<bool> UpdateReviewByCustomerIdAndProductIdAsync(Review review);
        // -- function to delete 1 review by using customer_id and product_id
        Task<bool> DeleteReviewByCustomerIdAndProductIdAsync(int userId, int productId);
        // -- function to delete 1 review by using customer_id
        Task<bool> DeleteReviewByCustomerIdAsync(int userId);
        // -- function to delete 1 review by using product_id
        Task<bool> DeleteReviewByProductIdAsync(int productId);

    }
}