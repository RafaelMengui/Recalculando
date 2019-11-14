//--------------------------------------------------------------------------------
// <copyright file="UFactoryFeedback.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.Item;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la resposable de agregar los componentes feedback al juego.
    /// Hereda de la Clase abstracta <see cref="FactoryUnity"/>.
    /// </summary>
    public class UFactoryFeedback : FactoryUnity
    {
        /// <summary>
        /// Objeto feedback que se agregara a Unity.
        /// </summary>
        private Feedback feedback;

        /// <summary>
        /// Sobrescribe el metodo abstracto de FactoryUnity.
        /// Tiene la responsabilidad de agregar el componente de tipo <see cref="feedback"/> a Unity.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
            try
            {
                // Se castea el componente como feedback.
                this.feedback = component as Feedback;
            }
            catch (System.Exception)
            {
                throw new System.Exception("Fail to cast component as feedback");
            }

            // Se crea el objeto en unity y se obtiene el UnityID.
            this.feedback.ID = adapter.CreateLabel(this.feedback.PositionX, this.feedback.PositionY, this.feedback.Width, this.feedback.Height); 

            adapter.SetFont(this.feedback.ID, this.feedback.Bold, this.feedback.Italic, this.feedback.Size);   

            // Se asigna el texto inicial del feedback.        
            adapter.SetText(this.feedback.ID, this.feedback.Text, true);
        }
    }
}