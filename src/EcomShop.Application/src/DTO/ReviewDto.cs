using System;
using System.Collections.Generic;
using EcomShop.Core.src.Entity;

namespace EcomShop.Application.src.DTO
{
    public class ReviewCreateDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public decimal Rating { get; set; }
        public string ReviewText { get; set; }

        public Review CreateReview(Review review)
        {
            return new Review
            {
                UserId = UserId,
                ProductId = ProductId,
                Date = Date,
                Rating = Rating,
                ReviewText = ReviewText
            };
        }
    }

    public class ReviewReadDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public decimal Rating { get; set; }
        public string ReviewText { get; set; }

        public void Transform(Review review)
        {
            Id = review.Id;
            UserId = review.UserId;
            ProductId = review.ProductId;
            Date = review.Date;
            Rating = review.Rating;
            ReviewText = review.ReviewText;
        }

        public static IEnumerable<ReviewReadDto> ConvertList(IEnumerable<Review> reviews)
        {
            var reviewDtos = new List<ReviewReadDto>();

            foreach (var review in reviews)
            {
                var reviewDto = new ReviewReadDto();
                reviewDto.Transform(review);
                reviewDtos.Add(reviewDto);
            }

            return reviewDtos;
        }
    }

    public class ReviewUpdateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public decimal Rating { get; set; }
        public string ReviewText { get; set; }

        public Review UpdateReview(Review oldReview)
        {
            oldReview.Date = Date;
            oldReview.Rating = Rating;
            oldReview.ReviewText = ReviewText;
            return oldReview;
        }
    }
}
