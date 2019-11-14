//--------------------------------------------------------------------------------
// <copyright file="UFactoryButtonStartLevel.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.Item;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la resposable de agregar los componentes ButtonGoToPage al juego.
    /// Hereda de la Clase abstracta <see cref="FactoryUnity"/>.
    /// </summary>
    public class UFactoryButtonStartLevel: FactoryUnity
    {
        /// <summary>
        /// Objeto ButtonGoToPage que se agregara a Unity.
        /// </summary>
        private ButtonStartLevel buttonStartLevel;

        /// <summary>
        /// Sobrescribe el metodo abstracto de FactoryUnity.
        /// Tiene la responsabilidad de agregar el componente de tipo <see cref="ButtonGoToPage"/> a Unity.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
            try
            {
                // Castear como ButtonGoToPage.
                this.buttonStartLevel = component as ButtonStartLevel;
            }
            catch (System.Exception)
            {
                throw new System.Exception("Fail to cast component as ButtonStartLevel");
            }

            // Asignar evento del boton.
            this.buttonStartLevel.Event = adapter.ShowPage;

            // Convierte a la pagina en donde debe ser creado el boton, en la pagina activa.
            adapter.ShowPage(this.buttonStartLevel.Level.ID);

            // Crear objeto en unity y obtener el UnityID.
            this.buttonStartLevel.ID = adapter.CreateButton(this.buttonStartLevel.PositionX, this.buttonStartLevel.PositionY, this.buttonStartLevel.Width, this.buttonStartLevel.Height, this.buttonStartLevel.Color, this.buttonStartLevel.Click);

            // Asignarle su imagen al boton.
            adapter.SetImage(this.buttonStartLevel.ID, this.buttonStartLevel.Image);

            // Se quita la palabra "Button".
            adapter.SetText(this.buttonStartLevel.ID, string.Empty);
        }
    }
}