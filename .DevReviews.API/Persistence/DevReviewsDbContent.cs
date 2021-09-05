using System.Collections.Generic;
using Entity;

namespace Persistence
{
    public class DevReviewsDbContent
    {
        public DevReviewsDbContent()
        {
            Products = new List<Product>();
        }
        public List<Product> Products { get; set; }
        
        
    }
}