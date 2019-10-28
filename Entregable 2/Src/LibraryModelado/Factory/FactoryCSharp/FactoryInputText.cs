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
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryInputText : IFactoryComponent
    {
        /// <summary>
        /// Nombre del input.
        /// </summary>
        private string name;

        /// <summary>
        /// Imagen del input.
        /// </summary>
        private string photo;

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
                this.name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
                this.level = this.world.SpaceList.Last();
                this.width = Convert.ToSingle(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Width"; }).Valor);
                this.height = Convert.ToSingle(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Height"; }).Valor);
                this.positionX = Convert.ToSingle(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
                this.positionY = Convert.ToSingle(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
            }

            catch (NullReferenceException)
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

            Items input = new InputText(this.name, this.level, this.positionX, this.positionY, this.width, this.height, null);
            this.level.ItemList.Add(input);
            return input;
        }
    }
}