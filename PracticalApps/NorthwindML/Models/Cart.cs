// Models a user's cart

using System.Collections.Generic;

namespace NorthwindML.Models {
    public class Cart {
        public IEnumerable<CartItem> Items { get; set; }
    }
}