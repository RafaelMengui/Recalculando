//--------------------------------------------------------------------------------
// <copyright file="FactoryDraggableItem.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.Linq;
using Proyecto.Item.KitchenLevel;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;
using System.Collections.Generic;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de crear items que van a ser arrastables.
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryRecipe : IFactoryComponent
    {
        /// <summary>
        /// Nombre del item.
        /// </summary>
        private string name;

        private Space level;

        public List<Food> foodlist;

        /// <summary>
        /// Instancia del mundo.
        /// </summary>
        private World world = Singleton<World>.Instance;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryComponent.
        /// Tiene la responsabilidad de crear el componente de tipo <see cref="Recipe"/>.
        /// </summary>
        /// <param name="tag">Tag <see cref="Tag"/>.</param>
        /// <returns>Componente <see cref="IComponent"/>.</returns>
        public override IComponent MakeComponent(Tag tag)
        {
            try
            {
                this.name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
                this.level = this.world.SpaceList.Last();

                foreach (Food food in this.level.ItemList)
                {
                    if(food.Type == tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Food"; }).Valor)
                    {

                    }
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException($"Missing attribute in tag \"{tag.Nombre}\".");
            }
            catch (InvalidCastException)
            {
                throw new InvalidCastException($"Failed cast operation in tag \"{tag.Nombre}\".");
            }
            catch (FormatException)
            {
                throw new FormatException($"Invalid attribute format in tag \"{tag.Nombre}\".");
            }

            Recipe recipe = new Recipe(this.name, this.level);
            this.level.ItemList.Add(recipe);
            this.container.SavedItems.Add(recipe);
            return recipe;
        }
    }
}