using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.FactoryCSharp2
{
    public class FactorySpace
    {
        private string name, image;
        World world = Singleton<World>.Instance;

        public IComponent MakeSpace(Tag tag)
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