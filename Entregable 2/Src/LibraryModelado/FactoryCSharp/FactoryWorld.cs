using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.FactoryCSharp
{
    public class FactoryWorld : IFactoryComponent
    {
        public override IComponent MakeComponent(Tag tag)
        {
            World world = Singleton<World>.Instance;
            string name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            world.Name = name;
            return world;
        }
    }
}