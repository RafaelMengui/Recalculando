using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace Version1
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
			/// <summary>
			/// Creamos un nuevo descargador pasándole una ubicación
			/// </summary>

			Downloader downloader = new Downloader(uri);
			/// <summary>
			/// Pedimos al descargador que descargue el contenido
			/// </summary>
			List<string> content;
			content = downloader.Download();
			/// <summary>
			/// Retorna una lista, con lineas del html
			/// </summary>
			return content;
		}
	}
}