using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace WieIsHet.Data
{
    public class BestandLader
    {
        public List<Persoon> LeesBestand()
        {
            JObject o1 = JObject.Parse(File.ReadAllText(@"WieIsHet.json"));
            JObject jsonPersonen = (JObject)o1["personen"];
            return jsonPersonen.Properties().Select(p =>
            {
                var persoon = new Persoon
                {
                    Naam = p.Name,
                };
                var jPersoon = (JArray) p.Value;
                var eigenschappen = jPersoon.Cast<JValue>().Select(naam => new Eigenschap((string)naam.Value));
                foreach (var eigenschap in eigenschappen)
                {
                    persoon.Eigenschappen.Add(eigenschap);
                }
                return persoon;
            }).ToList();
        }
    }
}