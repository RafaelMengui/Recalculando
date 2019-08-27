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
        public ArrayList leer_Archivo()
        {
            ArrayList lista_lineas = new ArrayList();

            try
            {
                using (StreamReader sr = new StreamReader(this.ubicacion))
                {
                    string linea = "";
                    while (linea != "</html>")
                    {
                        linea = sr.ReadLine().Trim();
                        lista_lineas.Add(linea);
                    }
                }
                return lista_lineas;
            }

            catch (System.Exception E)
            {
                Console.WriteLine("\nError al leer el archivo.");
                throw E;
            }
        }
    }
}