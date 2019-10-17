using System.Collections.Generic;

namespace Proyecto.LeerHTML
{
    /// <summary>
    /// Clase Imprimir. Contiene metodos para imprimir los tags y atributos en ciertos formatos.
    /// </summary>
    public class Imprimir
    {
        /// <summary>
        /// Devuelve un string que contiene solamente los tags y sus respectivos atributos,
        /// separados por el caracter '\n', es decir, un tag o atributo por linea.
        /// </summary>
        /// <param name="archivoHTML">Ruta al archivo XML/HTML</param>
        /// <returns>string Texto formateado.</returns>
        public static string Formato(string archivoHTML)
        {
            List<Tag> tags = Parser.ParserHTML(LeerHtml.RetornarHTML(archivoHTML));
            string textoFormato = "";

            foreach (Tag T in tags)
            {
                textoFormato += T.Nombre + "\n" + T.RetornarAtributos();
            }
            return textoFormato;
        }
    }
}