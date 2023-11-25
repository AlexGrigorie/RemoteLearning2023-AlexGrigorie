namespace iQuest.GrandCircus.Animals
{
    internal class Dog : AnimalBase
    {
        public Dog(string name, string species) : base(name, species)
        {
        }
        public override string MakeSound()
        {
            return "Ham";
        }
    }
}
