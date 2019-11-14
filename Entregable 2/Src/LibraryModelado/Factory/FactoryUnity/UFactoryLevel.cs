//--------------------------------------------------------------------------------
// <copyright file="UFactoryLevel.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la resposable de agregar los componentes Space al juego.
    /// Hereda de la Clase abstracta <see cref="FactoryUnity"/>.
    /// </summary>
    public class UFactoryLevel : FactoryUnity
    {
        /// <summary>
        /// Objeto Space que se agregara a Unity.
        /// </summary>
        private Space level;

        /// <summary>
        /// Sobrescribe el metodo abstracto de FactoryUnity.
        /// Tiene la responsabilidad de agregar el componente de tipo <see cref="Space"/> a Unity.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
            try
            {
                // Se castea el componente como Space.
                this.level = component as Space;
            }
            catch (System.Exception)
            {
                throw new System.Exception("Fail to cast component as Space");
            }

            // Se reajustan las correnadas de la pantalla.
            this.level.Width = adapter.WorldWidth;
            this.level.Height = adapter.WorldHeight;

            // Se crea la pagina en unity y obtiene el UnityID.
            this.level.ID = adapter.AddPage();

            // Se crea una imagen de fondo para el nivel, y se obtiene el UnityID.
            string backgroundID = adapter.CreateImage(0, 0, adapter.WorldWidth, adapter.WorldHeight);

            // Se asigna su imagen al fondo del nivel.
            adapter.SetImage(backgroundID, this.level.Image);
        }
    }
}