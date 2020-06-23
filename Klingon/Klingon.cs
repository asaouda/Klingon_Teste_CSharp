using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Klingon_Desafio
{
    public class Klingon
    {
        readonly string _foo = "slfwk";
        readonly char[] _alfabetoKlingon = { 'k', 'b', 'w', 'r', 'q', 'd', 'n', 'f', 'x', 'j', 'm', 'l', 'v', 'h', 't', 'c', 'g', 'z', 'p', 's' };
        readonly char[] _alfabeto = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y' };

        public int GetQtdePreposicoes(string texto)
        {
            int qtdePrep = 0;
            foreach (var palavra in texto.Split(" "))
            {
                var ultimaLetra = palavra[palavra.Length - 1];
                if (palavra.Length == 3 && !_foo.Contains(ultimaLetra) && !palavra.Contains("d"))
                {
                    qtdePrep++;
                }

            }
            return qtdePrep;
        }

        public int GetQtdeVerbos(string texto, bool primeira)
        {
            int qtdeVerbo = 0;
            int qtdeVerboPrimeira = 0;
            foreach (var palavra in texto.Split(" "))
            {
                var ultimaLetra = palavra[palavra.Length - 1];
                var primeiraLetra = palavra[0];

                if (palavra.Length >= 8 && _foo.Contains(ultimaLetra))
                {
                    qtdeVerbo++;
                    if (!_foo.Contains(primeiraLetra))
                    {
                        qtdeVerboPrimeira++;
                    }
                }
            }
            if (primeira)
            {
                return qtdeVerboPrimeira;
            }
            else
            {
                return qtdeVerbo;
            }
        }

        private static string[] GetTextoSemRepeticao(string texto)
        {
            string textoSemRepeticao = "";
            foreach (var palavra in texto.Split(" "))
            {
                if (!textoSemRepeticao.Contains(" " + palavra + " "))
                {
                    if (textoSemRepeticao == "")
                    {
                        textoSemRepeticao += palavra;
                    }
                    else
                    {
                        textoSemRepeticao += " " + palavra;
                    }
                }
            }
            return textoSemRepeticao.Split(" ");
        }

        public string GetVocabulario(string texto)
        {
            var vocabulario = new Dictionary<string, string>();
            string[] textoSemRepeticao = GetTextoSemRepeticao(texto);
            string textoOrdenado = "";
            string ordemLetras = "";
            foreach (var palavra in textoSemRepeticao)
            {
                ordemLetras = "";
                foreach (var letra in palavra)
                {
                    ordemLetras += _alfabeto[Array.IndexOf(_alfabetoKlingon, letra)];
                }
                vocabulario.Add(palavra, ordemLetras);
            }

            var vocabularioOrdenado = vocabulario.OrderBy(x => x.Value);
            foreach (var item in vocabularioOrdenado)
            {
                textoOrdenado += item.Key + " ";
            }
            return textoOrdenado.TrimEnd();

        }

        public int GetNumerosBonitos(string texto)
        {
            int qtdeNumerosBonitos = 0;
            foreach (var palavra in texto.Split(" "))
            {
                long numero = 0;
                long peso = 1;
                foreach (var letra in palavra)
                {
                    numero += Array.IndexOf(_alfabetoKlingon, letra) * peso;
                    peso *= 20;
                }
                if (numero >= 440566 && numero % 3 == 0)
                {
                    qtdeNumerosBonitos++;
                }
            }
            return qtdeNumerosBonitos;
        }
    }
}
