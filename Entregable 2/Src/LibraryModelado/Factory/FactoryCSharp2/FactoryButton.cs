using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.FactoryCSharp2
{
    public class FactoryButton
    {
        private FactoryButtonGeneric factoryButtonGeneric;
        private FactoryButtonAudio factoryButtonAudio;
        private FactoryButtonGoToPage factoryButtonGoToPage;

        public IComponent MakeButton(Tag tag)
        {
            string buttonType = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Type"; }).Valor;

            switch (buttonType)
            {
                case "Button":
                    IComponent genericButton = factoryButtonGeneric.MakeButtonGeneric(tag);
                    return genericButton;

                case "Audio":
                    IComponent audioButton = factoryButtonAudio.MakeButtonAudio(tag);
                    return audioButton;
                
                case "GoToPage":
                    IComponent goToPageButton = factoryButtonGoToPage.MakeButtonGoToPage(tag);
                    return goToPageButton;

                default: throw new System.Exception($"Invalid Button Type {buttonType} in {tag.Nombre}");
            }
        }
    }
}