using LeerHTML;
using System;


namespace Proyecto.Filters
{
    public class FilterWorld : IFilter
    {
        public World world;
        public Tag Creator(Tag tag)

        {
            return tag; //notiene que retornar esto, es para que compile y subirlo.
           // World world = new World (tag.Nombre, atributoSize.valor, Lalistanicohacelo, lo que faltaaca)
        }
    }
}