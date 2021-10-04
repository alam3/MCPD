// Define custom view model type for populating the catalog page
// Class contains properties to store a summary of a category

namespace NorthwindCms.Models {
    public class CategoryItem {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PageUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}