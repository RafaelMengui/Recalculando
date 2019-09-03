using System;
using System.IO;
using System.Collections;

namespace Interpretar_HTML
{
    public class AbrirArchivo
    {
        public string ubicacion { get; set; }
        public AbrirArchivo(string Ubicacion)
        {
            this.ubicacion = Ubicacion;
        }
        // La funcion retorna un Arraylist, siendo cada item una linea del archivo.
        public ArrayList LeerArchivo()
        {
            ArrayList ListaLineas = new ArrayList();

            while (!UbicacionValida())
            {
                Console.WriteLine($"\nError al leer el archivo < {this.ubicacion} > Verifique la ruta y la extension del mismo:");
                this.ubicacion = Console.ReadLine();
            }

            // Cuando la ruta del archivo sea valida, se leera hasta el final del codigo.
            using (StreamReader sr = new StreamReader(this.ubicacion))
            {
                string linea = "";
                while (linea != "</html>")
                {
                    linea = sr.ReadLine().Trim();
                    ListaLineas.Add(linea);
                }
                return ListaLineas;
            }
        }
        public bool UbicacionValida()
        {
            //Chequea que la extension del archivo sea .html, y si el archivo ingresado existe.
            if (this.ubicacion.Substring(this.ubicacion.Length - 5, 5) == ".html")
            {
                try
                {
                    using (StreamReader sr = new StreamReader(this.ubicacion))
                    {
                        sr.ReadLine();
                        return true;
                    }
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}