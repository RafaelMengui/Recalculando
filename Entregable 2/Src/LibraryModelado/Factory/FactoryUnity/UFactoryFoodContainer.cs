//--------------------------------------------------------------------------------
// <copyright file="UFactoryFoodContainer.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.Item.KitchenLevel;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la resposable de agregar los componentes Bowl al juego.
    /// Hereda de la Clase abstracta <see cref="FactoryUnity"/>.
    /// </summary>
    public class UFactoryFoodContainer : FactoryUnity
    {
        /// <summary>
        /// Objeto Bowl que se agregara a Unity.
        /// </summary>
        private Bowl bowl;

        /// <summary>
        /// Sobrescribe el metodo abstracto de FactoryUnity.
        /// Tiene la responsabilidad de agregar el componente de tipo <see cref="Bowl"/> a Unity.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
            try
            {
                // Castear como Bowl.
                this.bowl = component as Bowl;
            }
            catch (System.Exception)
            {
                throw new System.Exception("Fail to cast component as Bowl");
            }

            // Crear objeto en unity y obtener el UnityID.
            this.bowl.ID = adapter.CreateImage(this.bowl.PositionX, this.bowl.PositionY, this.bowl.Width, this.bowl.Height);

            // Asignarle su imagen al container.
            adapter.SetImage(this.bowl.ID, this.bowl.Image);
        }
    }
}