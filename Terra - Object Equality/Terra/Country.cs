using System;

namespace iQuest.Terra
{
    public class Country : IComparable
    {
        public string Name { get; }

        public string Capital { get; }

        public Country(string name, string capital)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Capital = capital ?? throw new ArgumentNullException(nameof(capital));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Country country)) return false;

            return Name == country.Name && Capital == country.Capital;

        }
        public int CompareTo(object obj)
        {
            switch (obj)
            {
                case null:
                    return 1;
                case Country country:
                    return Name.CompareTo(country.Name);
                default:
                    throw new ArgumentException("The object must be Country type");
            }
        }

    }
}