using System;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de crear objetos componentes del juego. 
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryComponent : IFactoryComponent
    {
        private FactoryWorld factoryWorld = new FactoryWorld();
        private FactorySpace factorySpace = new FactorySpace();
        private FactoryItem factoryItem = new FactoryItem();

        protected World world = Singleton<World>.Instance;
        /// <summary>
        /// Se sobreescribe el método de la clase IFactoryComponent
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>IComponent</returns>
        public override IComponent MakeComponent(Tag tag)
        {
            switch (tag.Nombre)
            {
                case "World":
                    IComponent world = factoryWorld.MakeComponent(tag);
                    return world;
                    
                case "Level":
                    IComponent level = factorySpace.MakeComponent(tag);
                    return level;

                default:
                    IComponent item = factoryItem.MakeComponent(tag);
                    return item;
            }
        }        
    }
}