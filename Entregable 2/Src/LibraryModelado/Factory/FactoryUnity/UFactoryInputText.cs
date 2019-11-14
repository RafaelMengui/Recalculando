//--------------------------------------------------------------------------------
// <copyright file="UFactoryInputText.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.Item;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la resposable de agregar los componentes InputText al juego.
    /// Implementa la interfaz <see cref="IFactoryUnity"/>.
    /// </summary>
    public class UFactoryInputText : IFactoryUnity
    {
        /// <summary>
        /// Objeto InputText que se agregara a Unity.
        /// </summary>
        private InputText input;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryUnity.
        /// Tiene la responsabilidad de agregar el componente de tipo <see cref="InputText"/> a Unity.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
            try
            {
                // Se castea el componente como InputText.
                this.input = component as InputText;
            }
            catch (System.Exception)
            {
                throw new System.Exception("Fail to cast component as InputText");
            }

            // Se crea el objeto en unity y se obtiene el UnityID.
            this.input.ID = adapter.CreateInputField(this.input.PositionX, this.input.PositionY, this.input.Width, this.input.Height, this.input.Change, this.input.Edit);

            // Se actualiza el tipo de letra.
            adapter.SetFont(this.input.ID, this.input.Bold, this.input.Italic, this.input.Size);
        }
    }
}