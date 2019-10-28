//--------------------------------------------------------------------------------
// <copyright file="UFactoryButtonGoToPage.cs" company="Universidad Católica del Uruguay">
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
    /// Implementa la interfaz <see cref="IFactoryUnity"/>.
    /// </summary>
    public class UFactoryButtonGoToPage : IFactoryUnity
    {
        /// <summary>
        /// Objeto ButtonGoToPage que se agregara a Unity.
        /// </summary>
        private ButtonGoToPage buttonGoToPage;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryUnity.
        /// Tiene la responsabilidad de agregar el componente de tipo <see cref="ButtonGoToPage"/> a Unity.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
            try
            {
                // Castear como ButtonGoToPage.
                this.buttonGoToPage = component as ButtonGoToPage;
            }
            catch (System.Exception)
            {
                throw new System.Exception("Fail to cast component as ButtonGoToPage");
            }

            // Asignar evento del boton.
            this.buttonGoToPage.Event = adapter.ShowPage;

            // Crear objeto en unity y obtener el UnityID.
            this.buttonGoToPage.ID = adapter.CreateButton(this.buttonGoToPage.PositionX, this.buttonGoToPage.PositionY, this.buttonGoToPage.Width, this.buttonGoToPage.Height, this.buttonGoToPage.Color, this.buttonGoToPage.Click);

            // Asignarle su imagen al boton.
            adapter.SetImage(this.buttonGoToPage.ID, this.buttonGoToPage.Image);

            // Se quita la palabra "Button".
            adapter.SetText(this.buttonGoToPage.ID, string.Empty);
        }
    }
}