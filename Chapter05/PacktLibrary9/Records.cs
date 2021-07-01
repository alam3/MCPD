namespace Packt.Shared {
    public class ImmutablePerson {

        // 'init' keyword to set value during instantiation, but not after
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }

    // Records, using the 'record' keyword, makes the whole object immutable
    public record ImmutableVehicle {
        public int Wheels { get; init; }
        public string Color { get; init; }
        public string Brand { get; init; }
    }

    // Record using a constructor with positional parameters and deconstructor
    public record ImmutableAnimal {
        string Name;
        string Species;
        public ImmutableAnimal(string name, string species) {
            Name = name;
            Species = species;
        }
        public void Deconstruct(out string name, out string species) {
            name = Name;
            species = Species;
        }
    }
}