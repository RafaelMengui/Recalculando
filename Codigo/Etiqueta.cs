using System;

namespace Interpretar_HTML
{
    public class Etiqueta
    {
        //Definimos un constructor para la clase etiqueta
        public Etiqueta(string NombreTag, string Atributo)
        {
            this.NombreTag = NombreTag;
            this.Atributo = Atributo;
        }
        /* Definimos metodos de instancias para poder cambiar el nombre de la etiqueta y 
        su atributo  el valor (set), o obtenerlo (get)
        */
        public string NombreTag { get; set; }
        public string Atributo { get; set; }

        public void OrdenarEImprimirAtributos()
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