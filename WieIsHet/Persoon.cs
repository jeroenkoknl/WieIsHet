using System;
using System.Collections.Generic;

namespace WieIsHet
{
    public class Persoon
    {
        public Persoon(string naam, IEnumerable<Eigenschap> eigenschappen)
        {
            if (eigenschappen == null)
                throw new ArgumentNullException(nameof(eigenschappen));
            if (string.IsNullOrWhiteSpace(naam))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(naam));
            Naam = naam;
            Eigenschappen = new HashSet<Eigenschap>(eigenschappen);
        }

        public string Naam { get;  }

        public IEnumerable<Eigenschap> Eigenschappen { get; }

        public override string ToString() => Naam;
    }
}