using System;
using System.Linq;
using postgresql.model;

namespace postgresql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.Query();
           
        }

        private void Query()
        {
            using(var ctx = new sharksContext())
            {

                var q = from o in ctx.Spil
                        join betaler in ctx.Spiller on o.Betaler equals betaler.Id
                        select new { spiller = betaler.Navn, dato = o.DatoSpil };
                foreach (var item in q)
                {
                    Console.WriteLine(item.spiller + " " + item.dato);
                }

            }
        }
    }
}
