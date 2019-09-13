using System;
using System.IO;
using System.Reflection;

namespace Version2
{
    /// <summary>
    /// Pequeño programa para probar el funcionamiento de la clase Downloader.
    /// </summary>
    public static class LeerHTML
    {
        //variable constante con el nombre del archivo
        ///const String fileName = @"..\..\..\..\src\test.html";
        //const String fileName = @"..\..\..\..\src\test2.html";
        /// <summary>
        /// Punto de entrada
        /// </summary>
        public static string RetornarHTML(string fileName)
        {
            String path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
            UriBuilder builder = new UriBuilder("file", "", 0, path);
            String uri = builder.Uri.ToString();
            // Creamos un nuevo descargador pasándole una ubicación.
            Downloader downloader = new Downloader(uri);
            // Pedimos al descargador que descargue el contenido
            string content;
            content = downloader.Download();
            // Imprimimos el contenido en la consola y esperamos una tecla para terminar
            return content;
        }
    }
}