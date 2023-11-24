using System;

namespace iQuest.GrandCircus.Animals
{
    internal class Snake : AnimalBase
    {
        public Snake(string name, string spcies):base(name, spcies) { }

        public override string MakeSound()
        {
            return "SSSSSSSSSS";
        }
    }
}
