namespace iQuest.GrandCircus.Animals
{
    internal class Lion : AnimalBase
    {
        public Lion(string name, string species) : base(name, species)
        {
        }
        public override string MakeSound()
        {
            return "Roooarrr";
        }
    }
}
