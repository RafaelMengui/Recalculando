using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    public class FactorySpace : IFactoryComponent
    {
        private string name, image;
        World world = Singleton<World>.Instance;

        public override IComponent MakeComponent(Tag tag)
        {
            this.name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            this.image = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Background"; }).Valor;

            Space level = new Level(name, image);
            level.World = this.world;
            world.SpaceList.Add(level);
            return level;
        }
    }
}