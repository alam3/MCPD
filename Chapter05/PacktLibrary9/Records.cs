namespace Packt.Shared {
    public class ImmutablePerson {

        // 'init' keyword to set value during instantiation, but not after
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }
}