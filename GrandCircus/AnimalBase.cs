using iQuest.GrandCircus.Interfaces;
namespace iQuest.GrandCircus
{
    internal abstract class AnimalBase : IAnimal
    {
        public string Name { get; private set; }
        public string SpeciesName { get; private set; }
        public AnimalBase(string name, string species)
        {
            Name = name;
            SpeciesName = species;
        }

        public abstract string MakeSound();
    }
}
