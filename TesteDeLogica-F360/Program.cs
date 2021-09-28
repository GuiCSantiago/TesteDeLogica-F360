using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDeLogica_F360.Entity;

namespace TesteDeLogica_F360
{
    class Program
    {
        static void Main(string[] args)
        {
            string escolhaMenu;
            do
            {
                Console.Clear();
                string escolhaTexto;
                do
                {
                    Console.Write("Selecione o texto('A' ou 'B'): ");
                    escolhaTexto = Console.ReadLine().ToUpper().Trim();
                } while (!escolhaTexto.Equals("A") && !escolhaTexto.Equals("B"));

                Console.Clear();
                Console.WriteLine("Texto {0}: ", escolhaTexto);

                var path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())
                    .Parent.FullName, "Textos/klingon-texto" + escolhaTexto + ".txt");

                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string texto = sr.ReadToEnd();
                        if (!string.IsNullOrEmpty(texto))
                        {
                            var klingon = new Klingon(texto);
                            Console.WriteLine("O texto possui " + klingon.CalculaPreposicao() + " preposições.");
                            Console.WriteLine("O texto possui " + klingon.ListaVerbos.Count + " verbos, destes " +
                                klingon.CalculaVerbosPrimeiraPessoa() + " estão em primeira pessoa.");
                            Console.WriteLine("\n" + "O vocabulário ordenado é: \n" + klingon.ListaVocabulario());
                            Console.WriteLine("\n" + "O texto possui {0} números bonitos", klingon.ContaNumerosBonitos());
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro: " + e.Message);
                }
                Console.Write("\n"+"Voltar a escolha?(S): ");
                escolhaMenu = Console.ReadLine().ToUpper().Trim();
            } while (escolhaMenu.Equals("S"));
        }
    }
}
