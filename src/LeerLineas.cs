using System;
using System.IO;
using System.Reflection;
using System.Collections;

namespace src
{
	/// <summary>
	/// Pequeño programa para probar el funcionamiento de la clase Downloader.
	/// </summary>
	public static class LeerLineas
	{
		//variable constante con el nombre del archivo
		const String fileName = @"..\..\..\..\Extras\test.html";
		/// <summary>
		/// Punto de entrada
		/// </summary>
		public static ArrayList RetornarLineas()
		{
			String path = Path.Combine( Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
			UriBuilder builder = new UriBuilder("file", "", 0, path);
			String uri = builder.Uri.ToString();
			// Creamos un nuevo descargador pasándole una ubicación.
			Downloader downloader = new Downloader(uri);
			// Pedimos al descargador que descargue el contenido
			ArrayList content;
			content = downloader.Download();
			// Retorna un array, con lineas del html
			return content;
		}
	}
}