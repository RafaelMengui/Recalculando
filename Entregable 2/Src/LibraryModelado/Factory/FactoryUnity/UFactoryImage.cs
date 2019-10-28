//--------------------------------------------------------------------------------
// <copyright file="UFactoryImage.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.Item;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la resposable de agregar los componentes Image al juego.
    /// Implementa la interfaz <see cref="IFactoryUnity"/>.
    /// </summary>
    public class UFactoryImage : IFactoryUnity
    {
        /// <summary>
        /// Objeto Image que se agregara a Unity.
        /// </summary>
        private Image image;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryUnity.
        /// Tiene la responsabilidad de agregar el componente de tipo <see cref="Image"/> a Unity.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
            try
            {
                // Se castea el componente como Image.
                this.image = component as Image;
            }
            catch (System.Exception)
            {
                throw new System.Exception("Fail to cast component as Image");
            }

            // Se crea el objeto en unity y se obtiene el UnityID.
            this.image.ID = adapter.CreateImage(this.image.PositionX, this.image.PositionY, this.image.Width, this.image.Height);

            // Se asigna su imagen al Image.
            adapter.SetImage(this.image.ID, this.image.Image);
        }
    }
}