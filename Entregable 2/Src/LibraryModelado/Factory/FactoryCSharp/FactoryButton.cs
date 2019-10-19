using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de crear objetos Boton. 
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryButton : IFactoryComponent
    {
<<<<<<< HEAD
        private FactoryButtonGeneric factoryButtonGeneric;
        private FactoryButtonAudio factoryButtonAudio;
        private FactoryButtonGoToPage factoryButtonGoToPage;
        
    /// <summary>
    /// Se sobreescribe el método de la clase IFactoryComponent
    /// </summary>
    /// <param name="tag"></param>
    /// <returns> IComponent </returns>
=======
        private FactoryButtonGeneric factoryButtonGeneric = new FactoryButtonGeneric();
        private FactoryButtonAudio factoryButtonAudio = new FactoryButtonAudio();
        private FactoryButtonGoToPage factoryButtonGoToPage = new FactoryButtonGoToPage();

>>>>>>> a494cbbd6f68c7b819485ef66706e171203fb748
        public override IComponent MakeComponent(Tag tag)
        {
            string buttonType = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Type"; }).Valor;

            switch (buttonType)
            {
                case "Button":
                    IComponent genericButton = factoryButtonGeneric.MakeComponent(tag);
                    return genericButton;

                case "Audio":
                    IComponent audioButton = factoryButtonAudio.MakeComponent(tag);
                    return audioButton;
                
                case "GoToPage":
                    IComponent goToPageButton = factoryButtonGoToPage.MakeComponent(tag);
                    return goToPageButton;

                default: throw new System.Exception($"Invalid Button Type {buttonType} in {tag.Nombre}");
            }
        }
    }
}