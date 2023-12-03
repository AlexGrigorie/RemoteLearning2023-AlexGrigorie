namespace iQuest.GrandCircus.Interfaces
{
    internal interface IAnimal
    {
        public string Name { get; }
        public string SpeciesName { get; }
        public string MakeSound();
    }
}
