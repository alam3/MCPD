using static System.Console;

namespace Packt.Shared {

    // Implementing the IPlayable interface
    public class DvdPlayer : IPlayable {
        public void Play() {
            WriteLine("DVD player is playing.");
        }
        public void Pause() {
            WriteLine("DVD player is pausing.");
        }

        // Previous to C#8.0, there was no way to expand the interface contract
        // without modifying the Interface itself and every implementation
    }
}