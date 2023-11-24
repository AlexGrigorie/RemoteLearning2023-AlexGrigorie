using System;

namespace iQuest.GrandCircus.Animals
{
    internal class Cat : AnimalBase
    {
        public Cat(string name, string species) : base(name, species)
        {
        }

        public override string MakeSound()
        {
            return "Meaowww";
        }
    }
}
