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
        private string name, color, image, pageName;
        private int width, height, positionX, positionY;
        private Space level;
        World world = Singleton<World>.Instance;
        /// <summary>
        ///  Se sobreescribe el método de la clase IFactoryComponent
        /// </summary>
        /// <param name="tag"></param>
        /// <returns> Items </returns>

        public override IComponent MakeComponent(Tag tag)
        {
            this.name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            this.level = world.SpaceList.Last();
            this.width = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Width"; }).Valor);
            this.height = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Height"; }).Valor);
            this.positionX = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
            this.positionY = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
            this.color = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Color"; }).Valor;
            this.image = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Photo"; }).Valor;
            this.pageName = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "GoToPage"; }).Valor;

            Items buttonGoToPage = new ButtonGoToPage(this.name, this.level, this.positionX, this.positionY, this.width, this.height, this.image, this.color, this.pageName);
            this.level.ItemList.Add(buttonGoToPage);
            return buttonGoToPage;
        }
    }
}