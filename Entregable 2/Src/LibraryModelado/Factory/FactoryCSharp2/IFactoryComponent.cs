using Proyecto.LibraryModelado;
using Proyecto.LeerHTML;

namespace Proyecto.FactoryCSharp2
{
    public abstract class IFactoryComponent
    {
        public abstract IComponent MakeComponent(Tag tag);
    }
}