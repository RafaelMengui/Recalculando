//--------------------------------------------------------------------------------
// <copyright file="FactorySpace.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
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
        /// <summary>
        /// Nombre del espacio.
        /// </summary>
        private string name;

        /// <summary>
        /// Imagen del espacio.
        /// </summary>
        private string image;

        /// <summary>
        /// Instancia del mundo.
        /// </summary>
        private World world = Singleton<World>.Instance;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryComponent.
        /// Tiene la responsabilidad de crear el componente de tipo <see cref="Space"/>.
        /// </summary>
        /// <param name="tag">Tag <see cref="Tag"/>.</param>
        /// <returns>Componente <see cref="IComponent"/>.</returns>
        public override IComponent MakeComponent(Tag tag)
        {
            this.name = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Name"; }).Valor;
            this.image = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Background"; }).Valor;
            Space level = new Level(this.name, this.image);
            level.World = this.world;
            this.world.SpaceList.Add(level);
            return level;
        }
    }
}