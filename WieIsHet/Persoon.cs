using System.Collections.Generic;

namespace WieIsHet
{
    public class Persoon
    {
        private readonly HashSet<Eigenschap> eigenschappen = new HashSet<Eigenschap>();

        public string Naam { get; set; }

        public ISet<Eigenschap> Eigenschappen => eigenschappen;

        public override string ToString()
        {
            return Naam;
        }
    }
}