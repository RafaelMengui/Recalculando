using Proyecto.LeerHTML;
using Proyecto;
namespace Proyecto.Pipes
{
    public class PipeNull : IPipe
    {
        public Tag Send(Tag tag)
        {
            return tag;
        }
    }
}