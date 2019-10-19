using System;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    public class FactoryComponent : IFactoryComponent
    {
        private FactoryWorld factoryWorld = new FactoryWorld();
        private FactorySpace factorySpace = new FactorySpace();
        private FactoryItem factoryItem = new FactoryItem();

        protected World world = Singleton<World>.Instance;

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