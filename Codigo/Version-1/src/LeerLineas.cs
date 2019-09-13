using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace src
{
	/// <summary>
	/// Pequeño programa para probar el funcionamiento de la clase Downloader.
	/// </summary>
	public static class LeerLineas
	{
		/// <summary>
		/// Punto de entrada
		/// </summary>
		public static List<string> RetornarLineas(string fileName)
		{
			String path = Path.Combine( Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
			UriBuilder builder = new UriBuilder("file", "", 0, path);
			String uri = builder.Uri.ToString();
			// Creamos un nuevo descargador pasándole una ubicación.
			Downloader downloader = new Downloader(uri);
			// Pedimos al descargador que descargue el contenido
			List<string> content;
			content = downloader.Download();
			// Retorna un array, con lineas del html
			return content;
		}
	}
}