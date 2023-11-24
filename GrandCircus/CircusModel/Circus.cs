using iQuest.GrandCircus.Animals;
using iQuest.GrandCircus.Interfaces;
using iQuest.GrandCircus.Presentation;
using System.Collections.Generic;

namespace iQuest.GrandCircus.CircusModel
{
    internal class Circus
    {
        private List<IAnimal> animals = new List<IAnimal>();
        private readonly Arena arena;
        public Circus(Arena arena)
        {
            this.arena = arena;
            animals = new List<IAnimal>
            {
                new Snake("Boa", "snake"),
                new Lion("King","Lion"),
                new Elephant("Cici", "Borneo"),
                new Dog("Thor", "Labrador"),
                new Cat("Pufi", "Birman")
            };
        }

        public void Perform()
        {
            arena.PresentCircus("Spectacular Circus");
            foreach (var animal in animals)
            {
                arena.AnnounceAnimal(animal.Name, animal.SpeciesName);
                arena.DisplayAnimalPerformance(animal.MakeSound());
            }
        }
    }
}