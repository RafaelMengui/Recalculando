using Proyecto.LibraryModelado;
using Proyecto.LeerHTML;
namespace Proyecto.FactoryCSharp
{
    public abstract class IFactoryComponent
    {
        public abstract IComponent MakeComponent(Tag tag);
    }
}