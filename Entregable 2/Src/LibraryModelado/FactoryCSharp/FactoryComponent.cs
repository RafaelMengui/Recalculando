using System;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.FactoryCSharp
{
    public class FactoryComponent : IFactoryComponent
    {
        private FactoryWorld factoryWorld;
        private FactorySpace factorySpace;
        private FactoryItem factoryItem;

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
                case "Items":
                    IComponent item = factoryItem.MakeComponent(tag);
                    return item;

                default: throw new System.Exception($"Invalid Tag Name {tag.Nombre}");
            }
        }        
    }
}