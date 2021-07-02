using static System.Console;

namespace Packt.Shared {

    // C#8.0 Default Implementations for an Interface
    public interface IPlayable {
        void Play();
        void Pause();

        // Default implementation
        // C#8.0 and above allows expanding the base Interface, without
        // modifying all its existing implementations, as long as it 
        // has a default implementation
        void Stop() {
            WriteLine("Default implementation of Stop.");
        }
    }
}