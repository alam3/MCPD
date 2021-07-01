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
}