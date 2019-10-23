//--------------------------------------------------------------------------------
// <copyright file="FactoryButton.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de delegar la responsabilidad de crear Botones.
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryButton : IFactoryComponent
    {
        /// <summary>
        /// Instancia de la fabrica responsable de crear Botones genericos en el modelado.
        /// </summary>
        /// <returns>Componentes del tipo <see cref="IComponent"/>.</returns>
        private FactoryButtonGeneric factoryButtonGeneric = new FactoryButtonGeneric();

        /// <summary>
        /// Instancia de la fabrica responsable de crear botones de audio en el modelado.
        /// </summary>
        /// <returns>Componentes del tipo <see cref="IComponent"/>.</returns>
        private FactoryButtonAudio factoryButtonAudio = new FactoryButtonAudio();

        /// <summary>
        /// Instancia de la fabrica responsable de crear botones GoToPage en el modelado.
        /// </summary>
        /// <returns>Componentes del tipo <see cref="IComponent"/>.</returns>
        private FactoryButtonGoToPage factoryButtonGoToPage = new FactoryButtonGoToPage();

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryComponent.
        /// Es responsable de delegar la responsabilidad de crear Botones, a sus respectivos Factorys.
        /// </summary>
        /// <param name="tag">Tag <see cref="Tag"/>.</param>
        /// <returns>Componente <see cref="IComponent"/>.</returns>
        public override IComponent MakeComponent(Tag tag)
        {
            string buttonType = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Type"; }).Valor;
            switch (buttonType)
            {
                case "Button":
                    {
                        IComponent genericButton = this.factoryButtonGeneric.MakeComponent(tag);
                        return genericButton;
                    }

                case "Audio":
                    {
                        IComponent audioButton = this.factoryButtonAudio.MakeComponent(tag);
                        return audioButton;
                    }

                case "GoToPage":
                    {
                        IComponent goToPageButton = this.factoryButtonGoToPage.MakeComponent(tag);
                        return goToPageButton;
                    }

                default: throw new System.Exception($"Invalid Button Type {buttonType} in {tag.Nombre}");
            }
        }
    }
}