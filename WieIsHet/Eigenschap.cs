using System;

namespace WieIsHet
{
    public class Eigenschap
    {
        public Eigenschap(string naam)
        {
            if (String.IsNullOrWhiteSpace(naam))
            {
                throw new ArgumentException("Argument is null or whitespace", nameof(naam));
            }
            Naam = naam;
        }

        public string Naam { get; }

        public string Vraag => $"Heeft de persoon {Naam}?";

        public override string ToString()
        {
            return Naam;
        }

        protected bool Equals(Eigenschap other)
        {
            return string.Equals(Naam, other.Naam);
        }

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
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((Eigenschap) obj);
        }

        public override int GetHashCode()
        {
            return Naam.GetHashCode();
        }
    }
}