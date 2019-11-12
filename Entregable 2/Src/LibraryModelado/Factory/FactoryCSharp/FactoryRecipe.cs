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
using Proyecto.LibraryModelado.Engine;
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

        /// <summary>
        /// Espacio del item.
        /// </summary>
        private Space level;
        /// <summary>
        /// Lista de objetos food de item.
        /// </summary>
        private List<Food> foodList;

        /// <summary>
        /// Lista de strings con los tipos de food.
        /// </summary>
        public Array foodListString;
        /// <summary>
        /// Lista con la cantidad de objetos food.
        /// </summary>
        public Array foodQuantityInt;

        /// <summary>
        /// Instancia del mundo.
        /// </summary>
        private World world = Singleton<World>.Instance;

        private EngineKitchenExercise1 engine = Singleton<EngineKitchenExercise1>.Instance;

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
                this.foodListString = (tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Food"; }).Valor).Split(',');
                this.foodQuantityInt = (tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Quantity"; }).Valor).Split(',');
                foreach (string foodString in this.foodListString)
                {
                    foreach (Food food in this.level.ItemList)
                    {
                        try
                        {

                            if (food.Type == foodString)
                            {
                                int index = Array.IndexOf(this.foodListString, foodString);

                                for (int i = 0; i < Convert.ToInt32(this.foodQuantityInt.GetValue(index)); i++)
                                {
                                    this.foodList.Add(food);
                                }
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            throw new IndexOutOfRangeException($"The index got out of range \"{tag.Nombre}\".");
                        }
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

            Recipe recipe = new Recipe(this.name, this.level, this.foodList);
            this.engine.recipeList.Add(recipe);
            return recipe;
        }
    }
}