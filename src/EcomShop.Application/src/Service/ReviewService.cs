using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;

namespace EcomShop.Application.src.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepo _reviewRepository;

        public ReviewService(IReviewRepo reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<ReviewReadDto> CreateReviewAsync(ReviewCreateDto reviewDto)
        {
            var reviewEntity = reviewDto.CreateReview(new Review());
            var createdReview = await _reviewRepository.CreateReviewAsync(reviewEntity);
            var reviewReadDto = new ReviewReadDto();
            reviewReadDto.Transform(createdReview);
            return reviewReadDto;
        }

        public async Task<IEnumerable<ReviewReadDto>> GetAllReviewsAsync()
        {
            var reviews = await _reviewRepository.GetAllReviwesAsync();
            return ReviewReadDto.ConvertList(reviews);
        }

        public async Task<IEnumerable<ReviewReadDto>> GetAllReviewsByCustomerIdAsync(int customerId)
        {
            var reviews = await _reviewRepository.GetAllReviwesByCustomerIdAsync(customerId);
            return ReviewReadDto.ConvertList(reviews);
        }

        public async Task<IEnumerable<ReviewReadDto>> GetAllReviewsByProductIdAsync(int productId)
        {
            var reviews = await _reviewRepository.GetAllReviwesByProductIdAsync(productId);
            return ReviewReadDto.ConvertList(reviews);
        }
        public async Task<ReviewReadDto> GetReviewByCustomerIdAndProductIdAsync(int customerId, int productId)
        {
            var review = await _reviewRepository.GetReviewByCustomerIdAndProductIdAsync(customerId, productId);
            var reviewDto = new ReviewReadDto();
            reviewDto.Transform(review);
            return reviewDto;
        }
        public async Task<bool> UpdateReviewByCustomerIdAndProductIdAsync(int customerId, int productId, ReviewUpdateDto reviewDto)
        {
            var existingReview = await _reviewRepository.GetReviewByCustomerIdAndProductIdAsync(customerId, productId);
            if (existingReview == null)
                return false;

            existingReview = reviewDto.UpdateReview(existingReview);
            return await _reviewRepository.UpdateReviewByCustomerIdAndProductIdAsync(existingReview);
        }

        public async Task<bool> DeleteReviewByCustomerIdAndProductIdAsync(int customerId, int productId)
        {
            return await _reviewRepository.DeleteReviewByCustomerIdAndProductIdAsync(customerId, productId);
        }
        public Task<bool> DeleteReviewByCustomerIdAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteReviewByProductIdAsync(int productId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<ReviewReadDto>> GetAllReviewsByOrderIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }

    }
}