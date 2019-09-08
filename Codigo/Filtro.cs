using System;
using System.Collections;

namespace src
{
    //La Clase Filtro, realiza la lectura del texto, para serpararlo en sus respectivos tipos(atributo, tag)
    public class Filtro
    {
        public static ArrayList FiltrarTexto(ArrayList Texto)
        {
            ArrayList ListaTag = new ArrayList();

            string nombreTag = "";
            string Atributo = "";
            string clave = "";
            string valor = "";

            foreach (string linea in Texto)
            {
                //Primero se fija que sea la primera vez que aparece el tag y que no sea nulo. 
                ArrayList ListaAtributos = new ArrayList();
                if (linea != null && linea[0] == '<' && linea[1] != '/')
                {
                    int x = linea.IndexOf(' ');

                    // Para saber si contiene atributos buscamos un espacio, utilizando la función IndexOf.
                    if (x != -1)
                    {
                        // Se toma como el nombre hasta el primer espacio, lo restante serán atributos.
                        nombreTag = linea.Substring(0, linea.IndexOf(' ')).Replace("<", "").Replace("/", "");
                        Atributo = linea.Substring(linea.IndexOf(' ') + 1);

                        foreach (string atr in Atributo.Split(' '))
                        {
                            // Se seperan los atributos por clave y valor, se crea el objeto Atributo y se guarda en un array.
                            clave = atr.Split('=')[0];
                            valor = atr.Split('=')[1].Replace(@"""", "").Replace(">", "").Replace("/", "");
                            Atributos A = new Atributos(clave, valor);
                            ListaAtributos.Add(A);
                        }

                        // Se crean los objetos tag(nombreTag, Lista con objetos atributos), y se formatea la lista atributos
                        Tag T = new Tag(nombreTag, ListaAtributos);
                        ListaTag.Add(T);
                    }
                    else
                    {
                        // Si no tiene atributos, y no contiene un =, se creara un tag con solo el nombre. 
                        if (!linea.Contains('='))
                        {
                            nombreTag = linea.Replace("<", "").Replace(">", "").Replace("/", "");
                            ArrayList vacia = new ArrayList();
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