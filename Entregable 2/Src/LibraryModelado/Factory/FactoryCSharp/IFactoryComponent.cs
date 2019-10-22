using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;


namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Interfaz IFactoryComponent
    /// Todos los Factory serán de tipo IFactoryComponent
    /// </summary>
    public abstract class IFactoryComponent
    {
        public abstract IComponent MakeComponent(Tag tag);
    }
}