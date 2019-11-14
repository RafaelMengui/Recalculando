//--------------------------------------------------------------------------------
// <copyright file="UFactoryMoney.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.Item.ScientistLevel;
using Proyecto.LibraryModelado;
using Proyecto.LibraryModelado.Engine;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la resposable de agregar los componentes Money al juego.
    /// Hereda de la Clase abstracta <see cref="FactoryUnity"/>.
    /// </summary>
    public class UFactoryMoney : FactoryUnity
    {
        /// <summary>
        /// Objeto Money que se agregara a Unity.
        /// </summary>
        private Money money;

        /// <summary>
        /// Instancia del motor de unity.
        /// </summary>
        private EngineUnity engineUnity = Singleton<EngineUnity>.Instance;

        /// <summary>
        /// Sobrescribe el metodo abstracto de FactoryUnity.
        /// Tiene la responsabilidad de agregar el componente de tipo <see cref="Money"/> a Unity.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
            try
            {
                // Castear como Money.
                this.money = component as Money;
            }
            catch (System.Exception)
            {
                throw new System.Exception("Fail to cast component as Money");
            }

            // Crear objeto en unity y obtener el UnityID.
            this.money.ID = adapter.CreateImage(this.money.PositionX, this.money.PositionY, this.money.Width, this.money.Height);

            adapter.OnDrop = this.engineUnity.OnDrop;

            // Se define el objeto como arrastrable.
            adapter.MakeDraggable(this.money.ID, this.money.Draggable);

            // Se centra el objeto en su respectivo container.
            adapter.Center(this.money.ID, (this.money.Container as Items).ID);

            // Asignarle su imagen al item.
            adapter.SetImage(this.money.ID, this.money.Image);
        }
    }
}