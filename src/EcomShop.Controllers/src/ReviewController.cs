using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using Microsoft.AspNetCore.Mvc;

namespace EcomShop.Controllers.src
{
    [ApiController]
    [Route("api/v1/reviews")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<ActionResult<ReviewReadDto>> CreateReviewAsync(ReviewCreateDto reviewDto)
        {
            var createdReview = await _reviewService.CreateReviewAsync(reviewDto);
            return Ok(createdReview);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewReadDto>>> GetAllReviewsAsync()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<IEnumerable<ReviewReadDto>>> GetAllReviewsByCustomerIdAsync(int customerId)
        {
            var reviews = await _reviewService.GetAllReviewsByCustomerIdAsync(customerId);
            return Ok(reviews);
        }

        [HttpGet("product/{productId}")]
        public async Task<ActionResult<IEnumerable<ReviewReadDto>>> GetAllReviewsByProductIdAsync(int productId)
        {
            var reviews = await _reviewService.GetAllReviewsByProductIdAsync(productId);
            return Ok(reviews);
        }

        [HttpGet("{customerId}/{productId}")]
        public async Task<ActionResult<ReviewReadDto>> GetReviewByCustomerIdAndProductIdAsync(int customerId, int productId)
        {
            var review = await _reviewService.GetReviewByCustomerIdAndProductIdAsync(customerId, productId);
            if (review == null)
                return NotFound();

            return Ok(review);
        }

        [HttpPut("{customerId}/{productId}")]
        public async Task<ActionResult> UpdateReviewByCustomerIdAndProductIdAsync(int customerId, int productId, ReviewUpdateDto reviewDto)
        {
            var result = await _reviewService.UpdateReviewByCustomerIdAndProductIdAsync(customerId, productId, reviewDto);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{customerId}/{productId}")]
        public async Task<ActionResult> DeleteReviewByCustomerIdAndProductIdAsync(int customerId, int productId)
        {
            var result = await _reviewService.DeleteReviewByCustomerIdAndProductIdAsync(customerId, productId);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}