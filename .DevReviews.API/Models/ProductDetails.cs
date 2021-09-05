using System;
using System.Collections.Generic;
using Entity;

namespace Models
{
    public class ProductDetails
    {
        public ProductDetails(int id, string title, string description, decimal price, DateTime registered, List<ProductReviewViewModel> reviews)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Registered = registered;
            Reviews = reviews;
        }

        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public DateTime Registered { get; private set; }

        public List<ProductReviewViewModel> Reviews { get; private set; }


    }
    public class ProductReviewViewModel
    {
        public ProductReviewViewModel(int id, string author, int rating, string comments, DateTime registered)
        {
            Id = id;
            Author = author;
            Rating = rating;
            Comments = comments;
            Registered = registered;
        }

        public int Id { get; private set; }

        public string Author { get; private set; }

        public int Rating { get;private set; }

        public string Comments { get;private set; }

        public DateTime Registered { get;private set; }
    }
}