// Define custom view model type for populating the catalog page
// Class has property to reference the catalog page and a property to store a list of category summary items

using System. Collections.Generic;

namespace NorthwindCms.Models {
    public class CatalogViewModel {
        public CatalogPage CatalogPage { get; set; }
        public IEnumerable<CategoryItem> Categories { get; set; }
    }
}