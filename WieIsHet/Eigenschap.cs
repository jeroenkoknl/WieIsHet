using System;

namespace WieIsHet
{
    public class Eigenschap
    {
        public Eigenschap(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam))
            {
                throw new ArgumentException("Argument is null or whitespace", nameof(naam));
            }
            Naam = naam;
        }

        public string Naam { get; }

        public override string ToString() => Naam;

        protected bool Equals(Eigenschap other) => string.Equals(Naam, other.Naam);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }
            return Equals((Eigenschap) obj);
        }

        public override int GetHashCode() => Naam.GetHashCode();
    }
}