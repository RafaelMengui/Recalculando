//--------------------------------------------------------------------------------
// <copyright file="ReadHTML.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.IO;
using System.Reflection;


namespace Proyecto.LeerHTML
{
    /// <summary>
    /// Clase ReadHTML.
    /// </summary>
    public static class ReadHTML
    {
        /// <summary>
        /// Metodo que retorna todo el Archivo HTML en formato string.
        /// </summary>
        /// <param name="fileName">String ubicacion del archivo HTML.</param>
        /// <returns>string contenido del archivo.</returns>
        public static string ReturnHTML(string fileName)
        {
            String path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
            UriBuilder builder = new UriBuilder("file", string.Empty, 0, path);
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