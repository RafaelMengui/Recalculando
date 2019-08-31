using System;

namespace Interpretar_HTML
{
    public class Etiqueta
    {
        public Etiqueta(string NombreTag, string Atributo)
        {
            this.NombreTag = NombreTag;
            this.Atributo = Atributo;
        }

        public string NombreTag { get; set; }
        public string Atributo { get; set; }

        public void OrdenarYImprimirAtributos()
        {
            string x = "";
            string atr = this.Atributo;
            foreach (char c in atr)
            {
                if (c == ' ')
                {
                    x += "\n";
                }
                else
                {
                    x += c;
                }
            }
            Console.WriteLine(x);
        }
    }
}