using System;
using System.Collections;
using System.Collections.Generic;

namespace Version1
{
    class Program
    {
        /// <summary>
        /// El programa inicial es el que imprime por consola el HTML final 
        /// </summary>
        static void Main()
        {
            const string ArchivoHTML = @"..\..\..\..\..\HTML-Prueba\test.html";

            List<Tag> tags = Filtro.FiltrarTexto(LeerLineas.RetornarLineas(ArchivoHTML));

            foreach (Tag T in tags)
            {
                Console.WriteLine(T.Nombre);
                T.ImprimirAtributos();
            }
        }
    }
}

