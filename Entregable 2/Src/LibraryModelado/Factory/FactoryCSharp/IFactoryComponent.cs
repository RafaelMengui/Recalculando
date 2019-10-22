<<<<<<< HEAD
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

=======
//--------------------------------------------------------------------------------
// <copyright file="IFactoryComponent.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;
>>>>>>> e3c183023df7a3ba0f9d45240444cd3108cd750e

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Interfaz IFactoryComponent.
    /// Todos los Factory serán de tipo IFactoryComponent.
    /// </summary>
    public abstract class IFactoryComponent
    {
        /// <summary>
        /// Metodo Abstracto para crear un objeto Componente a partir de un tag.
        /// </summary>
        /// <param name="tag"><see cref="Tag"/>.</param>
        /// <returns><see cref="IComponent"/>.</returns>
        public abstract IComponent MakeComponent(Tag tag);
    }
}