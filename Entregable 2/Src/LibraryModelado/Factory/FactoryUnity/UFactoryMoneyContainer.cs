//--------------------------------------------------------------------------------
// <copyright file="UFactoryMoneyContainer.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.Item.ScientistLevel;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la resposable de agregar los componentes MoneyContainer al juego.
    /// Hereda de la Clase abstracta <see cref="FactoryUnity"/>.
    /// </summary>
    public class UFactoryMoneyContainer : FactoryUnity
    {
        /// <summary>
        /// Objeto MoneyContainer que se agregara a Unity.
        /// </summary>
        private MoneyContainer moneyContainer;

        /// <summary>
        /// Sobrescribe el metodo abstracto de FactoryUnity.
        /// Tiene la responsabilidad de agregar el componente de tipo <see cref="MoneyContainer"/> a Unity.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
            try
            {
                // Castear como MoneyContainer.
                this.moneyContainer = component as MoneyContainer;
            }
            catch (System.Exception)
            {
                throw new System.Exception("Fail to cast component as MoneyContainer");
            }

            // Crear objeto en unity y obtener el UnityID.
            this.moneyContainer.ID = adapter.CreateImage(this.moneyContainer.PositionX, this.moneyContainer.PositionY, this.moneyContainer.Width, this.moneyContainer.Height);

            // Asignarle su imagen al container.
            adapter.SetImage(this.moneyContainer.ID, this.moneyContainer.Image);
        }
    }
}