//--------------------------------------------------------------------------------
// <copyright file="IFactoryComponent.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Clase abstracta de la fabrica de objetos IComponent en el modelado de C#.
    /// Todos los Factory serán de tipo CFactory.
    /// </summary>
    public abstract class CFactory
    {
        /// <summary>
        /// Metodo Abstracto para crear un objeto Componente a partir de un tag.
        /// </summary>
        /// <param name="tag"><see cref="Tag"/>.</param>
        /// <returns><see cref="IComponent"/>.</returns>
        public abstract IComponent MakeComponent(Tag tag);
    }
}