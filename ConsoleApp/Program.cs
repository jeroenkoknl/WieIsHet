using System;
using System.Collections.Generic;
using System.Linq;
using WieIsHet;
using WieIsHet.Data;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var personen = new BestandLader().LeesBestand();

            while (true)
            {
                Console.Clear();

                var persoon = Raad(personen);
                Console.WriteLine($"Het is {persoon.Naam}!");
                Console.WriteLine();
                Console.Write("Nog een potje? ");
                if (!Answer())
                {
                    break;
                }

            }
        }

        private static Persoon Raad(List<Persoon> personen)
        {
            if (personen.Count == 1)
            {
                return personen[0];
            }
            var eigenschappenAantal = personen.SelectMany(p => p.Eigenschappen).GroupBy(e => e).Select(g => new { Eigenschap = g.Key, Aantal = g.Count() }).ToList();

            int helft = personen.Count / 2;

            Eigenschap eigenschap = null;
            for (int i = helft; i > 0; i--)
            {
                eigenschap = eigenschappenAantal.Where(ea => ea.Aantal == i).Select(ea => ea.Eigenschap).FirstOrDefault();
                if (eigenschap != null)
                {
                    break;
                }
            }
            Console.Write(eigenschap.Vraag);
            Console.Write(" ");
            var answer = Answer();
            if (answer)
            {
                personen = personen.Where(p => p.Eigenschappen.Contains(eigenschap)).ToList();
            }
            else
            {
                personen = personen.Where(p => !p.Eigenschappen.Contains(eigenschap)).ToList();
            }
            return Raad(personen);
        }

        private static bool Answer()
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
