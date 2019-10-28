//--------------------------------------------------------------------------------
// <copyright file="UFactoryButtonTrueFalse.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.Item;
using Proyecto.Item.ScientistLevel;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la resposable de agregar los componentes ButtonTrueFalse al juego.
    /// Implementa la interfaz <see cref="IFactoryUnity"/>.
    /// </summary>
    public class UFactoryButtonTrueFalse : IFactoryUnity
    {
        /// <summary>
        /// Objeto ButtonTrueFalse que se agregara a Unity.
        /// </summary>
        private ButtonTrueFalse buttonTrueFalse;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryUnity.
        /// Tiene la responsabilidad de agregar el componente de tipo <see cref="ButtonTrueFalse"/> a Unity.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
            try
            {
                // Castear como ButtonTrueFalse.
                this.buttonTrueFalse = component as ButtonTrueFalse;
            }
            catch(System.Exception)
            {
                throw new System.Exception("Fail to cast component as ButtonTrueFalse");
            }

            // Crear objeto en unity y obtener el UnityID.
            this.buttonTrueFalse.ID = adapter.CreateButton(this.buttonTrueFalse.PositionX, this.buttonTrueFalse.PositionY, this.buttonTrueFalse.Width, this.buttonTrueFalse.Height, this.buttonTrueFalse.Color, this.buttonTrueFalse.Click);

            // Asignarle su imagen al boton.
            adapter.SetImage(this.buttonTrueFalse.ID, this.buttonTrueFalse.Image);

            // Se quita la palabra "Button".
            adapter.SetText(this.buttonTrueFalse.ID, string.Empty);
        }
    }
}