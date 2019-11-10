//--------------------------------------------------------------------------------
// <copyright file="UFactory.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto.Common;
using Proyecto.Item;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la responsable de delegar la responsabilidad de agregar los componentes al juego.
    /// En esta clase se ve claramente el Patrón de BAJO ACOMPLAMIENTO, debido a que nuestro juego
    /// esta completamente desacomplado de Unity, en caso de querer desplegar nuestro juego en otra
    /// plataforma podemos realizarlo. 
    /// Esta clase tiene un acomplamiento bajo, de la mano con esto podemos darnos cuenta que también
    /// cumple con el patron DON’T TALK TO STRANGERS. Esto se debe a que UFactory no conoce las conexiones
    /// internas y estructuras de otro objeto, sino que, se basa solamente en sí mismo para la creación de
    /// objetos, no necesita conocer a los objetos indirectos.
    /// Como dijimos anteriormente, esto lo hacemos para que Unity quede lo mas desacoplado posible de nuestro
    /// código.
    /// Implementa la interfaz <see cref="IFactoryUnity"/>.
    /// </summary>
    public class UFactory : IFactoryUnity
    {
        /// <summary>
        /// Diccionario en donde se asociara un componente con su respectivo Unity factory.
        /// </summary>
        private Dictionary<IFactoryUnity, string> componentUFactories = new Dictionary<IFactoryUnity, string>();

        /// <summary>
        /// Fabrica de unity generica utilizada para delegar la responsabilidad de agregar cada componente a su respectivo unity factory Concreto.
        /// </summary>
        private IFactoryUnity uFactory;

        /// <summary>
        /// Metodo estatico reponsable de instanciar la clase UFactory.
        /// </summary>
        /// <returns><see cref="IFactoryUnity"/>.</returns>
        public static IFactoryUnity InitializeUnityFactories() => new UFactory();

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryUnity.
        /// Delega la responsabilidad de agregar el componente en unity, al respectivo Unity Factory del componente.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
            string[] componentType = Convert.ToString(component.GetType()).Split('.');
            try
            {
                this.uFactory = Activator.CreateInstance(Type.GetType("Proyecto.Factory.Unity.UFactory" + componentType.Last())) as IFactoryUnity;
                this.componentUFactories.Add(this.uFactory, componentType.Last());
                this.uFactory.MakeUnityItem(adapter, component);
            }
            catch(System.ArgumentNullException)
            {
                throw new System.ArgumentNullException($"Unity Factory of {componentType.Last()} not found.");
            }
        }
    }
}
