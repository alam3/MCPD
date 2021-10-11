// Custom page type for the Catalog page. Acts as an entry point and container for category pages.

using Piranha.AttributeBuilder;
using Piranha.Models;

namespace NorthwindCms.Models {
    [PageType(Title = "Catalog page", UseBlocks = false)] // disable blocks use
    [ContentTypeRoute(Title = "Default", Route = "/catalog")] // define custom route path
    public class CatalogPage : Page<CatalogPage> {
    }
}