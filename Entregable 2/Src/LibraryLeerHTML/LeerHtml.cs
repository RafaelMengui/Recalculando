using System;
using System.IO;
using System.Reflection;

namespace Proyecto.LeerHTML
{
    /// <summary>
    /// Clase LeerHTML.
    /// </summary>
    public static class LeerHtml
    {
        /// <summary>
        /// Metodo que retorna todo el Archivo HTML en formato string.
        /// </summary>
        /// <param name="fileName">String ubicacion del archivo HTML.</param>
        /// <returns>string contenido del archivo.</returns>
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
            return content;
        }
    }
}