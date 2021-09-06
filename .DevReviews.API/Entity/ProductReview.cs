using System;

namespace Entity
{
    public class ProductReview
    {
        public ProductReview(string author, string name, string comments, int rating, int productId)
        {
            Author = author;
            Name = name;
            Comments = comments;
            Rating = rating;
            ProductId = productId;
            Registered = DateTime.Now;
        }

        public int Id { get; private set; }

        public string Author { get; private set; }

        public string Name { get; private set; }

        public string Comments { get; private set; }

        public int Rating { get; private set; }

        public DateTime Registered { get; set; }

        public int ProductId { get; private set; }
    }
}