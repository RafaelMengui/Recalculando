using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.FactoryCSharp2
{
    public class FactoryWorld
    {
        private string name;
        public IComponent MakeWorld(Tag tag)
        {
            World world = Singleton<World>.Instance;
            this.name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            world.Name = name;
            return world;
        }
    }
}