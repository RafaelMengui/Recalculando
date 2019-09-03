using System;
using System.Collections;

namespace Interpretar_HTML
{
    public class LeerArchivo
    {
        public static void LeerEImprimirArchivo()
        {
            Console.Write("Ubicacion del Archivo: "); string ub = Console.ReadLine();
            AbrirArchivo A1 = new AbrirArchivo(ub);
            ArrayList lista = A1.LeerArchivo();

            foreach (string l in lista)
            {
                Console.WriteLine(l);
            }
        }
    }
}