using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace WieIsHet.Data
{
    public class BestandLader : IBestandLader
    {
        public List<Persoon> LeesBestand()
        {
            var wieIsHetJson = JObject.Parse(File.ReadAllText(@"WieIsHet.json"));
            var jsonPersonen = (JObject)wieIsHetJson["personen"];
            return jsonPersonen.Properties().Select(p =>
            {
                var persoon = new Persoon
                {
                    Naam = p.Name
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