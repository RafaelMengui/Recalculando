//--------------------------------------------------------------------------------
// <copyright file="FactoryLabel.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.Linq;
using Proyecto.Item;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;
using Proyecto.LibraryModelado.Engine;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de crear las etiquetas.
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryFeedback : IFactoryComponent
    {
        /// <summary>
        /// Nombre de la Etiqueta.
        /// </summary>
        private string name;

        /// <summary>
        /// Imagen de la Etiqueta.
        /// </summary>
        private string photo;

        /// <summary>
        /// Ancho de la Etiqueta.
        /// </summary>
        private float width;

        /// <summary>
        /// Altura de la Etiqueta.
        /// </summary>
        private float height;

        /// <summary>
        /// Posicion en X de la Etiqueta.
        /// </summary>
        private float positionX;

        /// <summary>
        /// Posicion en Y de la Etiqueta.
        /// </summary>
        private float positionY;

        /// <summary>
        /// Nivel al que pertenece.
        /// </summary>
        private Space level;

        /// <summary>
        /// Texto de la etiqueta.
        /// </summary>
        private string text;

        /// <summary>
        /// Instancia del mundo.
        /// </summary>
        private World world = Singleton<World>.Instance;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryComponent.
        /// Tiene la responsabilidad de crear el componente de tipo <see cref="Label"/>.
        /// </summary>
        /// <param name="tag">Tag <see cref="Tag"/>.</param>
        /// <returns>Componente <see cref="IComponent"/>.</returns>
        public override IComponent MakeComponent(Tag tag)
        {
            try
            {
                this.name = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Name"; }).Valor;
                this.level = this.world.SpaceList.Last();
                this.width = Convert.ToSingle(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Width"; }).Valor);
                this.height = Convert.ToSingle(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Height"; }).Valor);
                this.positionX = Convert.ToSingle(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
                this.positionY = Convert.ToSingle(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
                this.photo = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Photo"; }).Valor;
                this.text = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Text"; }).Valor;
            }
            catch(NullReferenceException)
            {
                throw new NullReferenceException($"Missing attribute in tag \"{tag.Nombre}\".");
            }
            catch(InvalidCastException)
            {
                throw new InvalidCastException($"Failed cast operation in tag \"{tag.Nombre}\".");
            }
            catch(FormatException)
            {
                throw new FormatException($"Invalid attribute format in tag \"{tag.Nombre}\".");
            }

            Feedback feedback = new Feedback(this.name, this.level, this.positionX, this.positionY, this.width, this.height, this.photo, this.text);
            this.level.ItemList.Add(feedback);
            return feedback;
        }
    }
}