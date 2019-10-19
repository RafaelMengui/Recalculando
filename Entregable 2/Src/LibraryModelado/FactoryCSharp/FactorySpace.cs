using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.FactoryCSharp
{
    public class FactorySpace : IFactoryComponent
    {
        private string name, image;
        public override IComponent MakeComponent(Tag tag)
        {
            World world = Singleton<World>.Instance;
            name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            image = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Background"; }).Valor;

            Space level = new Level(name, image);
            level.World = world;
            world.SpaceList.Add(level);
            return level;
        }
    }
}