using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDeLogica_F360.Entity
{
    public class Klingon
    {
        public List<char> LetrasFoo { get; } = new List<char>() { 's', 'l', 'f', 'w', 'k' };

        public List<char> AlfabetoKlingon { get; } = new List<char>("kbwrqdnfxjmlvhtcgzps".ToCharArray());

        public List<char> Alfabeto { get; } = new List<char>("abcdefghijklmnopqrstuvwxyz".ToCharArray());

        public List<string> Lista { get; set; }

        public List<string> ListaVerbos { get; private set; }

        public Klingon(string texto)
        {
            Lista = texto.Split(' ').ToList();
            GeraListaVerbos();
        }

        public int CalculaPreposicao()
        {
            return Lista.Count(palavra => palavra.Length.Equals(3) &&
                !palavra.Contains('d') &&
                !LetrasFoo.Any(p => palavra.EndsWith(p.ToString())));
        }
        
        public void GeraListaVerbos()
        {
            ListaVerbos = Lista.Where(palavra => palavra.Length >= 8 &&
                LetrasFoo.Any(p => palavra.EndsWith(p.ToString())))
                .ToList();
        }

        public int CalculaVerbosPrimeiraPessoa()
        {
            return ListaVerbos
                .Where(verbo => !LetrasFoo.Any(p => verbo.StartsWith(p.ToString()))).Count();
        }
        
        public string ListaVocabulario()
        {      
            return string.Join(" ", Lista.OrderBy(palavra => ConvertePalavra(palavra)).Distinct().ToList());
        }

        public string ConvertePalavra(string palavra) //Converte a palavra Klingon em no nosso alfabeto 
        {
            string retorno = "";
            foreach (char letra in palavra.ToCharArray())
                retorno += Alfabeto[AlfabetoKlingon.IndexOf(letra)];
            
            return retorno;
        }

        public int ContaNumerosBonitos()
        {
            return Lista.Select(palavra => ConverteParaNumero(palavra)).Count(n => n >= 440566 && n % 3 == 0);
        }

        public long ConverteParaNumero(string palavra)
        {
            long valor = 0;
            for (int i = 0; i < palavra.Length; i++)
                valor += Convert.ToInt64((AlfabetoKlingon.IndexOf(palavra[i]) * Math.Pow(20, i))); 

            return valor;
        }
    }
}
