using System;
using AutoMapper;
using Entity;
using Models;

namespace Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductReview,ProductReviewViewModel>();
            CreateMap<ProductReview, ProductReviewDetailsViewModel>();
            CreateMap<Product,ProductViewModel>();
            CreateMap<Product,ProductDetails>();
        }
    }
}