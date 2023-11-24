using System;

namespace iQuest.GrandCircus.Animals
{
    internal class Elephant : AnimalBase
    {
        public Elephant(string name, string species) : base(name, species)
        {
        }

        public override string MakeSound()
        {
            return "Pftuuuu";
        }
    }
}
