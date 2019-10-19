using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;
using Proyecto.Item;
using System.Linq;
using System;

namespace Proyecto.FactoryCSharp2
{
    public class FactoryButtonAudio
    {
        private string name, color, image, audio;
        private int width, height, positionX, positionY;
        private Space level;
        World world = Singleton<World>.Instance;

        public IComponent MakeButtonAudio(Tag tag)
        {
            this.name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            this.level = world.SpaceList.Last();
            this.width = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Width"; }).Valor);
            this.height = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Height"; }).Valor);
            this.positionX = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
            this.positionY = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
            this.color = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Color"; }).Valor;
            this.image = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Photo"; }).Valor;
            this.audio = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Audio"; }).Valor;

            Items buttonAudio = new ButtonAudio(this.name, this.level, this.positionX, this.positionY, this.width, this.height, this.image, this.color, this.audio);
            this.level.ItemList.Add(buttonAudio);
            return buttonAudio;
        }
    }
}