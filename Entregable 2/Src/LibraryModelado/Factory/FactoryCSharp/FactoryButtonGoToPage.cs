//--------------------------------------------------------------------------------
// <copyright file="FactoryButtonGoToPage.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Proyecto.Item;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;
using System.Linq;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de crear objetos Boton para ir a la próxima página.
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryButtonGoToPage : IFactoryComponent
    {
        /// <summary>
        /// Nombre del boton.
        /// </summary>
        private string name;

        /// <summary>
        /// Color del boton.
        /// </summary>
        private string color;

        /// <summary>
        /// Imagen del boton.
        /// </summary>
        private string image;

        /// <summary>
        /// Pagina de destino del boton.
        /// </summary>
        private string pageName;

        /// <summary>
        /// Atributos int utilizados para crear el componente.
        /// </summary>
        private int width;

        /// <summary>
        /// Altura del boton.
        /// </summary>
        private int height;

        /// <summary>
        /// Posicion en X del boton.
        /// </summary>
        private int positionX;

        /// <summary>
        /// Posicion en Y del boton.
        /// </summary>
        private int positionY;

        /// <summary>
        /// Nivel al que pertenece el boton.
        /// </summary>
        private Space level;

        /// <summary>
        /// Instancia del mundo.
        /// </summary>
        private World world = Singleton<World>.Instance;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryComponent.
        /// Tiene la responsabilidad de crear el componente de tipo <see cref="ButtonGoToPage"/>.
        /// </summary>
        /// <param name="tag">Tag <see cref="Tag"/>.</param>
        /// <returns>Componente <see cref="IComponent"/>.</returns>
        public override IComponent MakeComponent(Tag tag)
        {
            this.name = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Name"; }).Valor;
            this.level = this.world.SpaceList.Last();
            this.width = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Width"; }).Valor);
            this.height = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Height"; }).Valor);
            this.positionX = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
            this.positionY = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
            this.color = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Color"; }).Valor;
            this.image = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Photo"; }).Valor;
            this.pageName = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "GoToPage"; }).Valor;
            Items buttonGoToPage = new ButtonGoToPage(this.name, this.level, this.positionX, this.positionY, this.width, this.height, this.image, this.color, this.pageName);
            this.level.ItemList.Add(buttonGoToPage);
            return buttonGoToPage;
        }
    }
}