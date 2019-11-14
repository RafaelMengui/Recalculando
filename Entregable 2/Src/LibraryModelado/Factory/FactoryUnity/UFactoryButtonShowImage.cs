//--------------------------------------------------------------------------------
// <copyright file="UFactoryButtonShowImage.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.Item;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la resposable de agregar los componentes ButtonShowImage al juego.
    /// Implementa la interfaz <see cref="IFactoryUnity"/>.
    /// </summary>
    public class UFactoryButtonShowImage : IFactoryUnity
    {
        /// <summary>
        /// Objeto ButtonShowImage que se agregara a Unity.
        /// </summary>
        private ButtonShowImage buttonShowImage;

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
                // Castear como ButtonShowImage.
                this.buttonShowImage = component as ButtonShowImage;
            }
            catch (System.Exception)
            {
                throw new System.Exception("Fail to cast component as ButtonShowImage");
            }

            // Convierte a la pagina en donde debe ser creado el boton, en la pagina activa.
            adapter.ShowPage(this.buttonShowImage.Level.ID);

            // Crear objeto en unity y obtener el UnityID.
            this.buttonShowImage.ID = adapter.CreateButton(this.buttonShowImage.PositionX, this.buttonShowImage.PositionY, this.buttonShowImage.Width, this.buttonShowImage.Height, this.buttonShowImage.Color, this.buttonShowImage.Click);

            // Asignarle su imagen al boton.
            adapter.SetImage(this.buttonShowImage.ID, this.buttonShowImage.Image);

            // Se quita la palabra "Button".
            adapter.SetText(this.buttonShowImage.ID, string.Empty);

            // Si la image que mostrara es este mimso item, inicialmente no aparecera en pantalla.
            if (this.buttonShowImage.Name.Equals(this.buttonShowImage.ImageName))
            {
                this.buttonShowImage.IsActive = false;
                adapter.SetActive(this.buttonShowImage.ID, false);
            }
        }
    }
}