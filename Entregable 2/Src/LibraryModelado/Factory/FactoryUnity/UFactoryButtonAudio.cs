//--------------------------------------------------------------------------------
// <copyright file="UFactoryButtonAudio.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.Item;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la resposable de agregar los componentes ButtonAudio al juego.
    /// Implementa la interfaz <see cref="IFactoryUnity"/>.
    /// </summary>
    public class UFactoryButtonAudio : IFactoryUnity
    {
        /// <summary>
        /// Objeto ButtonAudio que se agregara a Unity.
        /// </summary>
        private ButtonAudio buttonAudio;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryUnity.
        /// Tiene la responsabilidad de agregar el componente de tipo <see cref="ButtonAudio"/> a Unity.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
            // Castear como ButtonAudio.
            this.buttonAudio = component as ButtonAudio;

            // Asignar evento del boton.
            this.buttonAudio.Event = adapter.PlayAudio;

            // Crear objeto en unity y obtener el UnityID.
            this.buttonAudio.ID = adapter.CreateButton(this.buttonAudio.PositionX, this.buttonAudio.PositionY, this.buttonAudio.Width, this.buttonAudio.Height, this.buttonAudio.Color, this.buttonAudio.Click);

            // Asignarle su imagen al boton.
            adapter.SetImage(this.buttonAudio.ID, this.buttonAudio.Image);
 
            // Se quita la palabra "Button".
            adapter.SetText(this.buttonAudio.ID, string.Empty);
        }
    }
}