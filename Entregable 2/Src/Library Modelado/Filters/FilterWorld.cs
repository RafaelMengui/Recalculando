using Proyecto.LeerHTML;
using System.Collections.Generic;
using System;


namespace Proyecto.Filters
{
    /// <summary>
    /// Filtro de World.
    /// </summary>
    public class FilterWorld : IFilter
    {
        /// <summary>
        /// Filtro creador de objetos de World.
        /// </summary>
        /// <param name="tag">Tag que contenga informacion para crear objetos</param>
        /// <returns>retorna null al crear el mundo, en caso de que no pueda ser creado devuelve el tag.</returns>
        public Tag Creator(Tag tag)
        {
            string name = "";
            string width = "";
            string height = "";
            List<Space> listSpace = new List<Space>();
            
            if (tag.Nombre == "NewWorld")
            {
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
                if (!string.IsNullOrEmpty(name))
                {
                    World world = new World(name, width, height, listSpace);
                    return null;
                }
                return tag;
            }
            else
            {
                return tag;
            }
        }
    }
}