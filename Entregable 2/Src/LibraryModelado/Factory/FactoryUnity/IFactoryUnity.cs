//--------------------------------------------------------------------------------
// <copyright file="IFactoryUnity.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Interfaz IFactoryUnity.
    /// Todos los Unity Factory serán de tipo IFactoryUnity.
    /// </summary>
    public abstract class IFactoryUnity
    {
        /// <summary>
        /// Metodo Abstracto para agregar un objeto <see cref="IComponent"/>, a unity.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agragara a Unity, <see cref="IComponent"/>.</param>
        public abstract void MakeUnityItem(IMainViewAdapter adapter, IComponent component);
    }
}