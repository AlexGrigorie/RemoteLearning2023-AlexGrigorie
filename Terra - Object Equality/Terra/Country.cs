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
            if (obj == null)
                return false;

            Country country = obj as Country;
            if (country == null)
                return false;

            return Name == country.Name
                && Capital == country.Capital;
        }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if(!(obj is Country)) throw new ArgumentException("The object must be Country type");

            return Name.CompareTo((obj as Country).Name);
        }

    }
}