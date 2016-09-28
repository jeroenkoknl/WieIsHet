using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace WieIsHet.Data
{
    public class PersonenLader
    {
        private readonly FileInfo file;

        public PersonenLader(FileInfo file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));
            this.file = file;
        }

        public IEnumerable<Persoon> LeesPersonen()
        {
            var wieIsHetJson = JObject.Parse(File.ReadAllText(file.ToString()));
            var jsonPersonen = (JObject)wieIsHetJson["personen"];
            return jsonPersonen.Properties().Select(p =>
            {
                var jPersoon = (JArray) p.Value;
                var eigenschappen = jPersoon.Cast<JValue>().Select(naam => new Eigenschap((string)naam.Value));
                var persoon = new Persoon(p.Name, eigenschappen);
                return persoon;
            }).ToList();
        }
    }
}