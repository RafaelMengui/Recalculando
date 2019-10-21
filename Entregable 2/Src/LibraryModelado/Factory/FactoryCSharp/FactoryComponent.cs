//--------------------------------------------------------------------------------
// <copyright file="FactoryComponent.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de delegar la responsabilidad de crear componentes.
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryComponent : IFactoryComponent
    {
        /// <summary>
        /// Instancia de la fabrica responsable de crear el mundo.
        /// </summary>
        /// <returns>Componentes del tipo <see cref="IComponent"/>.</returns>
        private FactoryWorld factoryWorld = new FactoryWorld();

        /// <summary>
        /// Instancia de la fabrica responsable de crear un espacio en el modelado.
        /// </summary>
        /// <returns>Componentes del tipo <see cref="IComponent"/>.</returns>
        private FactorySpace factorySpace = new FactorySpace();

        /// <summary>
        /// Instancia de la fabrica responsable de delegar la responsabilidad de Crear los Items.
        /// </summary>
        /// <returns>Componentes del tipo <see cref="IComponent"/>.</returns>
        private FactoryItem factoryItem = new FactoryItem();

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryComponent.
        /// Es responsable de delegar la responsabilidad de crear componentes, a sus respectivos Factorys.
        /// </summary>
        /// <param name="tag">Tag <see cref="Tag"/>.</param>
        /// <returns>Componente <see cref="IComponent"/>.</returns>
        public override IComponent MakeComponent(Tag tag)
        {
            switch (tag.Nombre)
            {
                case "World":
                    {
                        IComponent world = this.factoryWorld.MakeComponent(tag);
                        return world;
                    }

                case "Level":
                    {
                        IComponent level = this.factorySpace.MakeComponent(tag);
                        return level;
                    }

                default:
                    {
                        IComponent item = this.factoryItem.MakeComponent(tag);
                        return item;
                    }
            }
        }
    }
}