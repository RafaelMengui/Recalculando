using System;
using System.Collections.Generic;

namespace LeerHTML
{
    public class Imprimir
    {
        /// <summary>
        /// Formatea el archivo HTML para su impresion.
        /// </summary>

        public static string Formato(string ArchivoHTML)
        {
            List<Tag> tags = Filtro.FiltrarHTML(LeerHtml.RetornarHTML(ArchivoHTML));
            string textoFormato = "";

            foreach (Tag T in tags)
            {
                textoFormato += T.Nombre + "\n" + T.RetornarAtributos();
            }
            return textoFormato;
        }
    }
}