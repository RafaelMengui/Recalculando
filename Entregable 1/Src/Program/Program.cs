using System;
using System.Collections;
using System.Collections.Generic;

namespace Version2
{
    class Program
    {
        /// <summary>
        /// El programa inicial utiliza las demas clases para imprimir el HTML final 
        /// </summary>
        static void Main()
        {
            const string ArchivoHTML = @"..\..\..\..\..\HTML-Prueba\test4.html";

            Console.WriteLine(Formato.Imprimir(ArchivoHTML));
        }
    }
}