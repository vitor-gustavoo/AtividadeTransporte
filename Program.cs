using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

using Controller;

namespace Linq
{
    public class ProgramLinq
    {
        public static void Main(string[] args)
        {
            List<cidadeController> cidades = new List<cidadeController>();
            cidades.Add(new cidadeController(1, "São Paulo"));
            cidades.Add(new cidadeController(2, "Rio de Janeiro"));
            cidades.Add(new cidadeController(3, "Belo Horizonte"));
            cidades.Add(new cidadeController(4, "Salvador"));
            cidades.Add(new cidadeController(5, "Curitiba"));
            cidades.Add(new cidadeController(6, "São Paulo"));
          
            IEnumerable<cidadeController> city = from cidade in cidades
                        where cidade.Nome == "São Paulo"
                        select cidade;

            foreach(cidadeController cidade in city)
            {
                Console.WriteLine(cidade.Id);
    
            }

            // Carro gol = (from carro in carros
            //             where carro.Marca == "Volkswagen"
            //             select carro).First();

            // int count = (from carro in carros
            //             where carro.Marca == "Volkswagen"
            //             select carro).Count();
        }
    }
}