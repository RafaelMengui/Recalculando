using System;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.FactoryCSharp2
{
    public class FactoryComponent : IFactoryComponent
    {
        private FactoryWorld factoryWorld;
        private FactorySpace factorySpace;
        private FactoryItem factoryItem;
        protected World world = Singleton<World>.Instance;

        public override IComponent MakeComponent(Tag tag)
        {
            switch (tag.Nombre)
            {
                case "World":
                    IComponent world = factoryWorld.MakeWorld(tag);
                    return world;

                case "Level":
                    IComponent level = factorySpace.MakeSpace(tag);
                    return level;

                case "Items":
                    IComponent item = factoryItem.MakeItems(tag);
                    return item;

                default: throw new System.Exception($"Invalid Tag Name {tag.Nombre}");
            }
        }
    }
}