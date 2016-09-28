using System;
using System.IO;
using System.Linq;
using WieIsHet;
using WieIsHet.Data;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var personenLader = new PersonenLader(new FileInfo(@"WieIsHet.json"));
            var personen = personenLader.LeesPersonen().ToList();
            while (true)
            {
                var spel = new Spel(personen);
                var speler = new Speler(spel);

                foreach (var vraag in speler.Vragen)
                {
                    Console.Write(vraag.Text);
                    Console.Write(" ");
                    vraag.Beantwoord(VraagAntwoord());
                }
                Console.WriteLine($"Het is {spel.GeradenPersoon}!");
                Console.WriteLine();
                Console.Write("Nog een potje? ");
                if (!VraagAntwoord())
                {
                    break;
                }
            }
        }

        private static bool VraagAntwoord()
        {
            bool? answer = null;
            while (true)
            {
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.KeyChar)
                {
                    case 'j':
                    case 'J':
                        answer = true;
                        break;
                    case 'n':
                    case 'N':
                        answer = false;
                        break;
                    default:
                        Console.Write("Druk op 'J' of 'N' ");
                        break;
                }
                if (answer.HasValue)
                {
                    break;
                }
            }
            return answer.Value;
        }
    }
}
