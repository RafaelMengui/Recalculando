//--------------------------------------------------------------------------------
// <copyright file="UFactoryFood.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.Item.KitchenLevel;
using Proyecto.LibraryModelado;
using Proyecto.LibraryModelado.Engine;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la resposable de agregar los componentes Food al juego.
    /// Hereda de la Clase abstracta <see cref="FactoryUnity"/>.
    /// </summary>
    public class UFactoryFood : FactoryUnity
    {
        /// <summary>
        /// Objeto Food que se agregara a Unity.
        /// </summary>
        private Food food;

        /// <summary>
        /// Instancia del motor de unity.
        /// </summary>
        private EngineUnity engineUnity = Singleton<EngineUnity>.Instance;

        /// <summary>
        /// Sobrescribe el metodo abstracto de FactoryUnity.
        /// Tiene la responsabilidad de agregar el componente de tipo <see cref="Food"/> a Unity.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
            try
            {
                // Castear como Food.
                this.food = component as Food;
            }
            catch (System.Exception)
            {
                throw new System.Exception("Fail to cast component as Food");
            }

            // Crear objeto en unity y obtener el UnityID.
            this.food.ID = adapter.CreateImage(this.food.PositionX, this.food.PositionY, this.food.Width, this.food.Height);

            // Se asigna el metodo OnDrop.
            adapter.OnDrop = this.engineUnity.OnDrop;

            // Se define el objeto como arrastrable.
            adapter.MakeDraggable(this.food.ID, this.food.Draggable);

            // Se centra el objeto en su respectivo container.
            adapter.Center(this.food.ID, (this.food.Container as Items).ID);

            // Asignarle su imagen al item.
            adapter.SetImage(this.food.ID, this.food.Image);
        }
    }
}