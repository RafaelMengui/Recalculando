using System;
using System.Collections.Generic;
using Proyecto.LeerHTML;

namespace Proyecto
{
    public class Creator 
    {
        public static World AddWorld(Tag tag)
        {
            string name = "";
            string width = "";
            string height = "";
            List<Space> listSpace = new List<Space>();

                foreach (Atributos atributo in tag.atributos)
                {
                    if (atributo.clave == "name")
                    {
                        name = atributo.valor;
                    }
                    else if (atributo.clave == "size")
                    {
                        string[] size = atributo.valor.Split('x');
                        width = size[0];
                        height = size[1];
                    }
                }
                
            World world = new World(tag.Nombre, width, height, listSpace);

            return world;
        }
    }
}

