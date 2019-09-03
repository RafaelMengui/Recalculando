using System;
using System.Collections;

namespace Interpretar_HTML
{
        /*Busca un archivo html e imprime todas las etiquetas del mismo,
        por principio de SRP, separamos el codigo en varias clases para que la 
        clase tenga una unica razón de cambio.
        */  
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