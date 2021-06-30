namespace Packt.Shared {
    public partial class Person {
        // 'Partial' class file of the Person class
        public string Origin {
            // readonly property only has a 'get' implementation
            get {
                return $"{Name} was born on {HomePlanet}";
            }
        }
        public string Greeting => $"{Name} says 'Hello!'";
        public int Age => System.DateTime.Today.Year - DateOfBirth.Year;

        // Settable properties
        public string FavoriteIceCream { get; set; }
        // Private field with public property gives more control
        private string favoritePrimaryColor;
        public string FavoritePrimaryColor {
            get {
                return favoritePrimaryColor;
            }
            set {
                switch (value.ToLower()) {
                    case "red":
                    case "green":
                    case "blue":
                        favoritePrimaryColor = value;
                        break;
                    default:
                        throw new System.ArgumentException($"{value} is not a primary color. " + 
                                                           "Choose from: red, green, blue.");
                }
            }
        }

        // Using Indexer to allow array-like accessor syntax to a property
        // Indexing the 'Person' class Children field
        public Person this[int index] {
            get {
                return Children[index];
            }
            set {
                Children[index] = value;
            }
        }
        // Indexer can be overloaded using a different indexing type
    }
}