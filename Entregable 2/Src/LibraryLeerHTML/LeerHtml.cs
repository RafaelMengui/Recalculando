using System;
using System.IO;
using System.Reflection;

namespace Proyecto.LeerHTML
{
    public static class LeerHtml
    {
        /// <summary>
        /// Retorna todo el Archivo HTML en formato string
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>string</returns>
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