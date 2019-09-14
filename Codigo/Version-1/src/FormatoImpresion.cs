using System;
using System.Collections.Generic;

namespace Version1
{
    public class Formato
    {
        /// <summary>
        /// Retorna el string del HTML final, ya formateado.
        /// </summary>
        
        //Usamos el principio de SRP teniendo una sola razón de cambio.   
        
        public static string Imprimir(string ArchivoHTML)
        {
            List<Tag> tags = Filtro.FiltrarTexto(LeerLineas.RetornarLineas(ArchivoHTML));
            string textoFormato = "";

            foreach (Tag T in tags)
            {
                textoFormato += T.Nombre + "\n" + T.RetornarAtributos();
            }
            return textoFormato;
        }
    }
}