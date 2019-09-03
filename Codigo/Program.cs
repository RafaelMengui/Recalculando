using System;
using System.IO;
using System.Collections;

namespace Interpretar_HTML
{
    class Program
    {
        static ArrayList ListaLineas = new ArrayList();
        static void AbrirYLeer(string ubicacion)
        {
            char[] Eliminar = new char[] { '"', '/' };
            string nombreTag = "";
            string atributo = "";

            using (StreamReader sr = new StreamReader(ubicacion))
            {
                string linea = "";

                while (linea != "</html>")
                {
                    linea = sr.ReadLine().Trim();
                    if (linea != null && linea[0] == '<' && linea[1] != '/')
                    {
                        int x = linea.IndexOf(' ');
                        if (x != -1)
                        {
                            nombreTag = linea.Substring(0, linea.IndexOf(' '));
                            atributo = linea.Substring(linea.IndexOf(' ') + 1);
                        }
                        else
                        {
                            nombreTag = linea.Replace("<", "").Replace(">", "");
                            atributo = "";
                        }
                        nombreTag = nombreTag.Replace("<", "").Replace(">", "").Replace("/", "");
                        atributo = atributo.Replace(@"""", "").Replace(">", "").Replace("/", "");

                        Etiqueta Tag = new Etiqueta(nombreTag, atributo);
                        Program.ListaLineas.Add(Tag);
                    }
                }
            }
        }
        static void Main()
        {
            Console.Write("Introduzca la Ubicación: "); string ubicacion = Console.ReadLine();
            AbrirYLeer(ubicacion);

            foreach (Etiqueta tag in Program.ListaLineas)
            {
                Console.WriteLine(tag.NombreTag);
                if (tag.Atributo != "")
                {
                    tag.OrdenarEImprimirAtributos();
                }
            }
        }
    }
}