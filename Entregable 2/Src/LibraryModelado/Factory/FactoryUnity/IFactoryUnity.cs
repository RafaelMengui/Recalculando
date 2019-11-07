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
    /// En esta interfaz utilizamos el Principio de SEGREGACIÓN de INTERFACES, este nos dice que,
    /// ninguna clase debería depender de métodos que no usa. Por tanto, creamos interfaces
    /// que definen comportamientos, las clases que necesiten de estos comportamientos van a
    /// implementar esta interfaz.En este caso, todos los factory de unity utiluzan esta interfaz. 
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