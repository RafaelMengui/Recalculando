//--------------------------------------------------------------------------------
// <copyright file="FactoryInputText.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.Linq;
using Proyecto.Item;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de crear las InputText.
    /// Hereda de la clase abstracta <see cref="CFactory"/>.
    /// </summary>
    public class FactoryInputText : CFactory
    {
        /// <summary>
        /// Nombre del input.
        /// </summary>
        private string name;

        /// <summary>
        /// Ancho del input.
        /// </summary>
        private float width;

        /// <summary>
        /// Altura del input.
        /// </summary>
        private float height;

        /// <summary>
        /// Posicion en X del input.
        /// </summary>
        private float positionX;

        /// <summary>
        /// Posicion en Y del input.
        /// </summary>
        private float positionY;

        /// <summary>
        /// Nivel al que pertenece.
        /// </summary>
        private Space level;

        /// <summary>
        /// Tamaño del texto.
        /// </summary>
        private int size;

        /// <summary>
        /// Bool si el texto va en negrita.
        /// </summary>
        private bool bold;

        /// <summary>
        /// Bool si el texto va en cursiva.
        /// </summary>
        private bool italic;

        /// <summary>
        /// Imagen del input.
        /// </summary>
        private string photo;

        /// <summary>
        /// Instancia del mundo.
        /// </summary>
        private World world = Singleton<World>.Instance;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryComponent.
        /// Tiene la responsabilidad de crear el componente de tipo <see cref="InputText"/>.
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
                this.size = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Size"; }).Valor);
                this.bold = Convert.ToBoolean(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Bold"; }).Valor);
                this.italic = Convert.ToBoolean(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Italic"; }).Valor);
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

            Items input = new InputText(this.name, this.level, this.positionX, this.positionY, this.width, this.height, this.photo, this.size, this.bold, this.italic);
            this.level.ItemList.Add(input);
            return input;
        }
    }
}