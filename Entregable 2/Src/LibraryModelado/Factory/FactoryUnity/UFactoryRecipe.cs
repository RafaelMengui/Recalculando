//--------------------------------------------------------------------------------
// <copyright file="UFactoryRecipe.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.LibraryModelado;
using Proyecto.LibraryModelado.Engine;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la resposable de agregar los componentes Recipe al juego.
    /// Hereda de la Clase abstracta <see cref="FactoryUnity"/>.
    /// </summary>
    public class UFactoryRecipe : FactoryUnity
    {
        /// <summary>
        /// Sobrescribe el metodo abstracto de FactoryUnity.
        /// Debido a que no crearemos un objeto Recipe en unity, esta clase no tiene ninguna responsabilidad,
        /// mas que asignarle al motor de unity el adaptador de tipo <see cref="IMainViewAdapter"/>.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
        }
    }
}