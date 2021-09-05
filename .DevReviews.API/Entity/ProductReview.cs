using System;

namespace Entity
{
    public class ProductReview
    {
        public ProductReview(int id, string author, int name, string comments, int rating, DateTime registered, int productId)
        {
            Id = id;
            Author = author;
            Name = name;
            Comments = comments;
            Rating = rating;
            Registered = registered;
            ProductId = productId;
        }

        public int Id { get; private set; }

        public string Author { get; private set; }

        public int Name { get; private set; }

        public string Comments { get; private set; }

        public int Rating { get; private set; }

        public DateTime Registered { get; set; }

        public int ProductId { get; private set; }

    }
}