using LeerHTML;

namespace Proyecto
{
    public class FilterLevel : IFilter
    {
        public Level level; 
        public Tag WorldCreator(Tag tag)
        {
            return tag;
        }
    }
}