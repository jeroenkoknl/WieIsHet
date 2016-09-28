using System;
using System.Collections.Generic;
using System.Linq;

namespace WieIsHet
{
    public class Spel
    {
        private List<Persoon> personen;

        public Spel(ICollection<Persoon> personen)
        {
            if (personen == null)
                throw new ArgumentNullException(nameof(personen));
            if (personen.Count == 0)
            {
                throw new ArgumentException("Collection should contain at least one element", nameof(personen));
            }
            this.personen = new List<Persoon>(personen);
        }

        public IEnumerable<Persoon> Personen => personen;

        public Persoon GeradenPersoon => personen.Single();

        public void VerwijderPersonenMetEigenschap(Eigenschap eigenschap, bool vanToepassing)
        {
            personen = personen.Where(p => p.Eigenschappen.Contains(eigenschap) ^ !vanToepassing).ToList();
        }
    }
}