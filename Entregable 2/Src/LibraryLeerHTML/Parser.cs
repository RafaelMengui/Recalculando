//--------------------------------------------------------------------------------
// <copyright file="Parser.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Proyecto.LeerHTML
{
    /// <summary>
    /// La Clase Parser es la CREATOR de Tag y Atributos.
    /// La elegimos como Creator debido a que la clase es abierta
    /// a la extensión pero cerrada a la modificación.
    /// Esto se realiza de esta forma ya que, siempre crearemos los objetos Tag de la misma forma y no debemos modificarlo,
    /// en caso de querer crear otro tipo de objetos, podemos realizarlo debido a que si es abierto a la extensión.
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// Metodo que extrae informacion de los tags (Nombre, clave y valor de los atributos).
        /// </summary>
        /// <param name="texto">Texto XML/HTML a filtrar.</param>
        /// <returns>Lista de objetos Tag.</returns>
        public static List<Tag> ParserHTML(string texto)
        {
            List<Tag> listaTag = new List<Tag>();
            string nombreTag = "";
            string atributo = "";
            string clave = "";
            string valor = "";
            string[] arrayTexto = texto.Split('<');
            foreach (string tag in arrayTexto)
            {
                List<Atributos> listaAtributos = new List<Atributos>();
                if (!tag.Trim().StartsWith("/"))
                {
                    int index = tag.IndexOf(' ');
                    if (index != -1)
                    {
                        nombreTag = tag.Substring(0, index).Replace("/", "");
                        atributo = tag.Substring(index + 1, tag.Length - index - tag.Substring(tag.IndexOf('>')).Length - 1);
                        foreach (string atr in atributo.Split(' '))
                        {
                            // Se separan los atributos por clave y valor, se crea el objeto Atributo y se guarda en un array.
                            clave = atr.Split('=')[0];
                            valor = atr.Split('=')[1].Replace(@"""", "");
                            if (!string.IsNullOrEmpty(valor))
                            {
                                valor = valor.Substring(0, valor.Length);
                            }
                            else
                            {
                                throw new ArgumentNullException($"Empty Tag Attributes: {nombreTag} has empty atributtes.");
                            }

                            Atributos A = new Atributos(clave, valor);
                            listaAtributos.Add(A);
                        }

                        // Se crean los objetos tag(nombreTag, Lista con objetos atributos)
                        Tag T = new Tag(nombreTag, listaAtributos);
                        listaTag.Add(T);
                    }
                    else
                    {
                        // Si no tiene atributos, y no contiene un =, se creara un tag con solo el nombre.
                        if (!string.IsNullOrEmpty(tag) && !tag.Contains("="))
                        {
                            nombreTag = tag.Substring(0, tag.IndexOf('>')).Replace("/", "");
                            List<Atributos> vacia = new List<Atributos>();
                            Tag A = new Tag(nombreTag, vacia);
                            listaTag.Add(A);
                        }
                    }
                }
            }
            
            return listaTag;
        }
    }
}