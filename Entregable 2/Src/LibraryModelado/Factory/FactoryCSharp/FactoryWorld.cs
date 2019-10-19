using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    public class FactoryWorld : IFactoryComponent
    {
        private string name;
        public override IComponent MakeComponent(Tag tag)
        {
            World world = Singleton<World>.Instance;
            this.name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            world.Name = name;
            return world;
        }
    }
}