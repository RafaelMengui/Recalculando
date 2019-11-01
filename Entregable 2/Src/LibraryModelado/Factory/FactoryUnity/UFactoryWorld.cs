//--------------------------------------------------------------------------------
// <copyright file="UFactoryWorld.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.LibraryModelado;
using Proyecto.LibraryModelado.Engine;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la resposable de agregar los componentes Space al juego.
    /// Implementa la interfaz <see cref="IFactoryUnity"/>.
    /// </summary>
    public class UFactoryWorld : IFactoryUnity
    {
        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryUnity.
        /// Debido a que no crearemos un objeto World en unity, esta clase no tiene ninguna responsabilidad,
        /// mas que asignarle al motor de unity el adaptador de tipo <see cref="IMainViewAdapter"/>.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
        }
    }
}