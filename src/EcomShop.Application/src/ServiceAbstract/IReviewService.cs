using EcomShop.Application.src.DTO;

namespace EcomShop.Application.src.ServiceAbstract
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewReadDto>> GetAllReviewsAsync();
        Task<IEnumerable<ReviewReadDto>> GetAllReviewsByCustomerIdAsync(int customerId);
        Task<IEnumerable<ReviewReadDto>> GetAllReviewsByProductIdAsync(int productId);
        Task<IEnumerable<ReviewReadDto>> GetAllReviewsByOrderIdAsync(int orderId);
        Task<ReviewReadDto> GetReviewByCustomerIdAndProductIdAsync(int customerId, int productId);
        Task<bool> UpdateReviewByCustomerIdAndProductIdAsync(int customerId, int productId, ReviewUpdateDto review);
        Task<bool> DeleteReviewByCustomerIdAndProductIdAsync(int customerId, int productId);
        Task<bool> DeleteReviewByCustomerIdAsync(int customerId);
        Task<bool> DeleteReviewByProductIdAsync(int productId);
        Task<ReviewReadDto> CreateReviewAsync(ReviewCreateDto review);
    }
}