using System;
using System.Collections.Generic;

namespace LeerHTML
{
    public class Imprimir
    {
        /// <summary>
        /// Devuelve un string que contiene solamente los tags y sus respectivos atributos,
        /// separados por el caracter '\n', es decir, un tag o atributo por linea.
        /// </summary>
        /// <param name="archivoHTML">Ruta al archivo XML/HTML</param>
        /// <returns>string</returns>
        public static string Formato(string archivoHTML)
        {
            List<Tag> tags = Filtro.FiltrarHTML(LeerHtml.RetornarHTML(archivoHTML));
            string textoFormato = "";

            foreach (Tag T in tags)
            {
                textoFormato += T.Nombre + "\n" + T.RetornarAtributos();
            }
            return textoFormato;
        }
    }
}