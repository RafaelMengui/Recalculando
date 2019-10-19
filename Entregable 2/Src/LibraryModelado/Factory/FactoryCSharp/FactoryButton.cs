using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    public class FactoryButton : IFactoryComponent
    {
        private FactoryButtonGeneric factoryButtonGeneric = new FactoryButtonGeneric();
        private FactoryButtonAudio factoryButtonAudio = new FactoryButtonAudio();
        private FactoryButtonGoToPage factoryButtonGoToPage = new FactoryButtonGoToPage();

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