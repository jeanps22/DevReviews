using System;

namespace Models
{
    public class ProductReviewDetailsViewModel
    {
        // public ProductReviewDetailsViewModel(int id, string author, int name, string comments, int rating, DateTime registered)
        // {
        //     Id = id;
        //     Author = author;
        //     Name = name;
        //     Comments = comments;
        //     Rating = rating;
        //     Registered = registered;
        // }

        public int Id { get; private set; }

        public string Author { get; private set; }

        public string Name { get; private set; }

        public string Comments { get; private set; }

        public int Rating { get; private set; }

        public DateTime Registered { get; private set; }
    }
}