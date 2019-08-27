using System;
using System.Collections;

namespace Interpretar_HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string ub = @"test.html";
            AbrirArchivo A1 = new AbrirArchivo(ub);
            ArrayList lista = A1.leer_Archivo();

            foreach (string l in lista)
            {
                Console.WriteLine(l);
            }
        }
    }
}
