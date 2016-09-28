using System;
using System.Collections.Generic;
using System.Linq;

namespace WieIsHet
{
    public class Speler
    {
        private readonly Spel spel;

        public Speler(Spel spel)
        {
            if (spel == null)
                throw new ArgumentNullException(nameof(spel));
            this.spel = spel;
        }

        public IEnumerable<Vraag> Vragen
        {
            get
            {
                for (var personen = spel.Personen.ToList(); personen.Count > 1; personen = spel.Personen.ToList())
                {
                    var eigenschappenAantal = personen.SelectMany(p => p.Eigenschappen).GroupBy(e => e).Select(g => new { Eigenschap = g.Key, Aantal = g.Count() }).ToList();

                    var helft = personen.Count / 2;

                    Eigenschap eigenschap = null;
                    for (var i = helft; i > 0; i--)
                    {
                        eigenschap = eigenschappenAantal.Where(ea => ea.Aantal == i).Select(ea => ea.Eigenschap).FirstOrDefault();
                        if (eigenschap != null)
                        {
                            break;
                        }
                    }
                    yield return new Vraag(eigenschap, spel);
                }
            }
        }
    }
}