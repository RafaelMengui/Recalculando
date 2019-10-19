using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de crear objetos Space. 
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactorySpace : IFactoryComponent
    {
        private string name, image;
        World world = Singleton<World>.Instance;

        /// <summary>
        /// Se sobreescribe el método de la clase IFactoryComponent
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>Space</returns>
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