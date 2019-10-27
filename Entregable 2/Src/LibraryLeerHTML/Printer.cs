//--------------------------------------------------------------------------------
// <copyright file="Printer.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;

namespace Proyecto.LeerHTML
{
    /// <summary>
    /// Clase Print. Contiene metodos para imprimir los tags y atributos en ciertos formatos.
    /// </summary>
    public class Printer
    {
        /// <summary>
        /// Devuelve un string que contiene solamente los tags y sus respectivos atributos,
        /// separados por el caracter '\n', es decir, un tag o atributo por linea.
        /// </summary>
        /// <param name="fileHTML">Ruta al archivo XML/HTML</param>
        /// <returns>string Texto formateado.</returns>
        public static string Format(string fileHTML)
        {
            List<Tag> tags = Parser.ParserHTML(ReadHTML.ReturnHTML(fileHTML));
            string textoFormato = "";
            foreach (Tag T in tags)
            {
                textoFormato += T.Nombre + "\n" + T.RetornarAtributos();
            }
            return textoFormato;
        }
    }
}