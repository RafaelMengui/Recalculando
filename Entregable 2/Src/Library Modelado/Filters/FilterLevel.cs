using Proyecto.LeerHTML;

namespace Proyecto
{
    public class FilterLevel : IFilter
    {
        public Level level; 
        public Tag Creator(Tag tag)
        {
            return tag;
        }
    }
}