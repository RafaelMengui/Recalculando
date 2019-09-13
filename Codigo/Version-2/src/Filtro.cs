using System;
using System.Collections;
using System.Collections.Generic;
namespace Version2
{
    public class Filtro
    {
        public static List<Tag> FiltrarHTML(string Texto)
        {
            List<Tag> ListaTag = new List<Tag>();

            string nombreTag = "";
            string Atributo = "";
            string clave = "";
            string valor = "";
            string[] texto = Texto.Split('<');

            foreach (string tag in texto)
            {
                List<Atributos> ListaAtributos = new List<Atributos>();

                if (!tag.Trim().StartsWith('/'))
                {
                    int index = tag.IndexOf(' ');

                    if (index != -1)
                    {
                        nombreTag = tag.Substring(0, index).Replace("/", "");
                        Atributo = tag.Substring(index + 1, tag.Length - index - tag.Substring(tag.IndexOf('>')).Length - 1);

                        foreach (string atr in Atributo.Split(' '))
                        {
                            /* Se separan los atributos por clave y valor, se crea el objeto
                                Atributo y se guarda en un array */

                            clave = atr.Split('=')[0];
                            valor = atr.Split('=')[1].Replace(@"""", "");

                            if (!string.IsNullOrEmpty(valor) && valor[valor.Length - 1] == '/')
                            {
                                valor = valor.Substring(0, valor.Length - 1);
                            }

                            Atributos A = new Atributos(clave, valor);
                            ListaAtributos.Add(A);
                        }

                        /* Se crean los objetos tag(nombreTag, Lista con objetos atributos)
                        y se agregan a una lista de tags */
                        Tag T = new Tag(nombreTag, ListaAtributos);
                        ListaTag.Add(T);
                    }
                    else
                    {
                        // Si no tiene atributos, y no contiene un "=", se creara un tag con solo el nombre. 
                        if (!string.IsNullOrEmpty(tag) && !tag.Contains('='))
                        {
                            nombreTag = tag.Substring(0, tag.IndexOf('>')).Replace("/", "");
                            List<Atributos> vacia = new List<Atributos>();
                            Tag A = new Tag(nombreTag, vacia);
                            ListaTag.Add(A);
                        }
                    }
                }
            }
            return ListaTag;
        }
    }
}