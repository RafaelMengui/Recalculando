using System;
using System.Collections.Generic;

namespace Proyecto.LeerHTML
{
    public class Imprimir
    {
        /// <summary>
        /// Retorna el string del HTML final, ya formateado.
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