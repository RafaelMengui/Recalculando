using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de crear objetos Mundo. 
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryWorld : IFactoryComponent
    {
        private string name;

        /// <summary>
        /// Se sobreescribe el método de la clase IFactoryComponent
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>World</returns>
        public override IComponent MakeComponent(Tag tag)
        {
            World world = Singleton<World>.Instance;
            this.name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            world.Name = name;
            return world;
        }
    }
}