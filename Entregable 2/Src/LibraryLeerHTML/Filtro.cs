using System;
using System.Collections;
using System.Collections.Generic;

namespace Proyecto.LeerHTML
{
    
    /// <summary>
    /// La Clase Filtro es nuestra Creator de Tag y Atributos.
    /// </summary>
    public class Filtro
    {
        public static List<Tag> FiltrarHTML(string texto)
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
                            
                            /// <summary>
                            /// Se separan los atributos por clave y valor, se crea el objeto Atributo y 
                            /// se guarda en un array.
                            /// </summary>
                            clave = atr.Split('=')[0];
                            valor = atr.Split('=')[1].Replace(@"""", "");

                            if (!string.IsNullOrEmpty(valor) && valor[valor.Length - 1] == '/')
                            {
                                valor = valor.Substring(0, valor.Length - 1);
                            }

                            Atributos A = new Atributos(clave, valor);
                            listaAtributos.Add(A);
                        }

                        /// <summary>
                        /// Se crean los objetos tag(nombreTag, Lista con objetos atributos)
                        /// </summary>
                        Tag T = new Tag(nombreTag, listaAtributos);
                        listaTag.Add(T);
                    }
                    else
                    {
                        /// <summary>
                        ///  Si no tiene atributos, y no contiene un =, se creara un tag con solo el nombre.
                        /// </summary>
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