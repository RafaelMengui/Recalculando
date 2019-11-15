//--------------------------------------------------------------------------------
// <copyright file="FactoryRecipe.cs" company="Universidad Católica del Uruguay">
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
    /// Hereda de la clase abstracta <see cref="CFactory"/>.
    /// </summary>
    public class FactoryRecipe : CFactory
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
        /// Lista de tipos de food.
        /// </summary>
        private Dictionary<string, int> foodList = new Dictionary<string, int>();

        /// <summary>
        /// Lista de strings con los tipos de food.
        /// </summary>
        public string[] foodTypes;

        /// <summary>
        /// Lista con la cantidad de objetos food.
        /// </summary>
        public string[] foodTypesQuantity;

        /// <summary>
        /// Instancia del mundo.
        /// </summary>
        private World world = Singleton<World>.Instance;

        private EngineGame engineGame = Singleton<EngineGame>.Instance;

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
                this.foodTypes = (tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Food"; }).Valor).Split(',');
                this.foodTypesQuantity = (tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Quantity"; }).Valor).Split(',');

                for (int i = 0; i < this.foodTypes.Length; i++)
                {
                    int quantity = Convert.ToInt32(this.foodTypesQuantity[i]);
                    this.foodList.Add(this.foodTypes[i], quantity);
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
            return recipe;
        }
    }
}