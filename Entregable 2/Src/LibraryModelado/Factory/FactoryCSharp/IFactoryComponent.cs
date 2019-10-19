using Proyecto.LibraryModelado;
using Proyecto.LeerHTML;

namespace Proyecto.Factory.CSharp
{
    public abstract class IFactoryComponent
    {
        public abstract IComponent MakeComponent(Tag tag);
    }
}