//--------------------------------------------------------------------------------
// <copyright file="FactoryComponent.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de delegar la responsabilidad de crear componentes.
    /// FactoryComponent cumple cn el PRINICIPIO OCP, el cual nos dice que Las clases
    /// deben ser abiertas a la extensión, pero cerradas a la modificación.Esto ocurre en
    /// esta clase debido a que, en caso de querer crear más componentes lo podemos hacer
    /// sin necesidad de modificar el código.
    /// Hereda de la clase abstracta <see cref="CFactory"/>.
    /// </summary>
    public class FactoryComponent : CFactory
    {
        /// <summary>
        /// Diccionario en donde se asociara un tag con su respectivo factory.
        /// </summary>
        private Dictionary<string, CFactory> componentFactories = new Dictionary<string, CFactory>();

        /// <summary>
        /// Fabrica generica utilizada para delegar la responsabilidad de crear cada componente a su respectivo factory Concreto.
        /// </summary>
        private CFactory factory;

        /// <summary>
        /// Metodo estatico reponsable de instanciar la clase FactoryComponent.
        /// </summary>
        /// <returns><see cref="CFactory"/>.</returns>
        public static CFactory InitializeFactories() => new FactoryComponent();

        /// <summary>
        /// Metodo responsable de delegar la responsabilidad de crear el componente.
        /// Intenta crear y asocia en el diccionario el nombre del componente (Tag.Nombre),
        /// con su respectivo factory.
        /// [OCP]
        /// </summary>
        /// <param name="tag">Tag <see cref="Tag"/>.</param>
        /// <returns>Componente <see cref="IComponent"/>.</returns>
        public override IComponent MakeComponent(Tag tag)
        {
            try
            {
                this.factory = Activator.CreateInstance(Type.GetType("Proyecto.Factory.CSharp.Factory" + tag.Nombre)) as CFactory;
            }
            catch (System.Exception)
            {
                throw new System.Exception($"Invalid Tag Name: {tag.Nombre}");
            }

            this.componentFactories.Add(tag.Nombre, this.factory);
            foreach (var type in this.componentFactories)
            {
                try
                {
                    IComponent component = this.componentFactories[type.Key].MakeComponent(tag);
                    return component;
                }
                catch (System.Exception)
                {
                    throw new System.Exception($"Failed to Instanciate \"{tag.Nombre}\" object, or Factory \"{type.Value}\" not found.");
                }
            }

            return null;
        }
    }
}
