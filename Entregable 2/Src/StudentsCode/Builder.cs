//--------------------------------------------------------------------------------
// <copyright file="Builder.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Proyecto.Common;
using Proyecto.Factory.CSharp;
using Proyecto.Factory.Unity;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;
using Proyecto.LibraryModelado.Engine;

namespace Proyecto.StudentsCode
{
    /// <summary>
    /// Clase que implementa la interfaz IBuilder.
    /// Tiene la responsabilidad de generar los archivos 'StudentsCode.dll' y 'Common.dll'.
    /// </summary>
    public class Builder : IBuilder
    {
        /// <summary>
        /// Instancia del motor principal.
        /// </summary>
        /// <returns></returns>
        private EngineGame engineGame = new EngineGame();
        
        /// <summary>
        /// Adapter del tipo <see cref="IMainViewAdapter"/>.
        /// </summary>
        private IMainViewAdapter adapter;

        /// <summary>
        /// Pagina inicial que se mostrara al ejecutar el juego.
        /// </summary>
        private Space firstPage;

        /// <summary>
        /// Instancia del unico mundo del tipo <see cref="World"/>.
        /// </summary>
        private World world = Singleton<World>.Instance;

        /// <summary>
        /// Instancia de la fabrica responsable de crear componentes del modelado.
        /// </summary>
        /// <returns>Componentes del tipo <see cref="IComponent"/>.</returns>
        private FactoryComponent factoryComponent = new FactoryComponent();

        /// <summary>
        /// Instancia de la fabrica responsable de agregar los objetos del modelado a unity.
        /// </summary>
        /// <returns>Void.</returns>
        private UFactory unityFactory = new UFactory();

        /// <summary>
        /// Construye una interfaz de usuario interactiva utilizando un <see cref="IMainViewAdapter"/>.
        /// </summary>
        /// <param name="providedAdapter">Un <see cref="IMainViewAdapter"/> que permite construir una interfaz de usuario interactiva.</param>
        public void Build(IMainViewAdapter providedAdapter)
        {
            this.adapter = providedAdapter ?? throw new ArgumentNullException(nameof(providedAdapter));
            this.adapter.AfterBuild += this.Setup;

            const string XMLfile = @"..\..\..\Code\Entregable 2\Src\ArchivosHTML\Prueba.xml";
            List<Tag> tags = Parser.ParserHTML(ReadHTML.ReturnHTML(XMLfile));

            List<IComponent> componentList = new List<IComponent>();
            foreach (Tag tag in tags)
            {
                IComponent component = this.factoryComponent.MakeComponent(tag);
                componentList.Add(component);
            }

            foreach (IComponent component in componentList)
            {
                this.unityFactory.MakeUnityItem(this.adapter, component);
            }

            this.firstPage = this.world.SpaceList[0];
            engineGame.MainPage = this.firstPage;
            this.adapter.AfterBuild();
        }

        /// <summary>
        /// Accion a realizar luego de Compilar el programa. Muestra la primera pagina en Unity.
        /// </summary>
        private void Setup()
        {
            this.adapter.ChangeLayout(Layout.ContentSizeFitter);
            this.adapter.ShowPage(this.firstPage.ID);
        }
    }
}

/*
Drop de Money
Drop de DraggableItems

*/