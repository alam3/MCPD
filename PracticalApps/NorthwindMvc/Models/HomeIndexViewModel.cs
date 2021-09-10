// Count number of visitors, have lists of categories and products

using System.Collections.Generic;
using Packt.Shared;

namespace NorthwindMvc.Models {
    public class HomeIndexViewModel {
        public int VisitorCount;
        public IList<Category> Categories { get; set; }
        public IList<Product> Products { get; set; }
    }
}