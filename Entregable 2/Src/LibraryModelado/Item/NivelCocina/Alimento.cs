using System;
using Proyecto.Common;
using Proyecto.LibraryModelado;

namespace Proyecto.Item.NivelCocina
{   
    /// <summary>
    /// Clase de Alimentos. Hereda de <see cref="Items"/>
    /// </summary>
    public class Food : Items
    {   
        /// <summary>
        /// Container en el que es creado inicialmente el Item.
        /// </summary>
        private Items container;
        
        /// <summary>
        /// Constructor. Instancia Objetos Food.
        /// </summary>
        /// <param name="name">Nombre del Food.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen del Food.</param>
        /// <param name="container">Container Source en donde es creado.</param>
        public Food(string name, Space level, int positionX, int positionY, int width, int height, string image, Items container)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.Container = container;
        }

        /// <summary>
        /// Gets or sets del container en el que es creado inicialmente el Item.
        /// </summary>
        /// <value><see cref="DragAndDropSource"/>.</value>
        public Items Container { get; set; }

        /// <summary>
        /// Metodo que guarde el item en el bowl
        /// </summary>
        /// <param name="Container"></param>
        public void DropFood(DragAndDropDestination Container)
        {
        }
        
        /// <summary>
        /// Metodo para crear DragAndDropItem (Food) en Unity.
        /// </summary>
        /// <param name="adapter">Adapter del tipo <see cref="IMainViewAdapter"/>.</param>
        public override void CreateUnityItem(IMainViewAdapter adapter)
        {
            this.ID = adapter.CreateDragAndDropItem(this.PositionX, this.PositionY, this.Width, this.Height);
            adapter.SetImage(this.ID, this.Image);
            adapter.AddItemToDragAndDropSource(this.Container.ID, this.ID);
        }
    }
}