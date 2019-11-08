//--------------------------------------------------------------------------------
// <copyright file="FactoryOperations.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de crear las Operationsnes.
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryOperations : IFactoryComponent
    {
        private string components;

        /// <summary>
        /// Nivel al que pertenece.
        /// </summary>
        private Space level;

        /// <summary>
        /// Lista en donde se guardaran los componentes asociados a la operacion.
        /// </summary>
        private List<Items> componentList = new List<Items>();

        /// <summary>
        /// Instancia del mundo.
        /// </summary>
        private World world = Singleton<World>.Instance;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryComponent.
        /// Tiene la responsabilidad de crear el componente de tipo <see cref="Operations"/>.
        /// </summary>
        /// <param name="tag">Tag <see cref="Tag"/>.</param>
        /// <returns>Componente <see cref="IComponent"/>.</returns>
        public override IComponent MakeComponent(Tag tag)
        {
            try
            {
                this.level = this.world.SpaceList.Last();
                this.components = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Components"; }).Valor;
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

            foreach (string componentName in this.components.Split(','))
            {
                try
                {
                    Items item = this.level.ItemList.Find(delegate(Items component) { return component.Name == componentName; });
                    this.componentList.Add(item);
                }
                catch (System.ArgumentNullException)
                {
                    throw new System.ArgumentNullException("Component in operation.", $"Invalid component name \"{componentName}\", in operation");
                }
            }

            Operations operation = new Operations(this.level, this.componentList);
            return operation;
        }
    }
}