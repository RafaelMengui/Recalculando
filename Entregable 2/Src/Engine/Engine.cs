using Proyecto.Item.KitchenLevel;
using Proyecto.Item.ScientistLevel;
using Proyecto.LibraryModelado;

namespace Proyecto.Engine
{
    /// <summary>
    /// *Patron Obsever*
    /// Clase motor, responsable de conectar el modelado con los eventos de Unity.
    /// </summary>
    public class Engine : IObserver
    {
        /// <summary>
        /// Metodo que verifica si sucedio algun cambio en el juego.
        /// </summary>
        public void Update()
        {
        }

        /// <summary>
        /// Metodo responsable de verificar si el objeto tipo Money soltado dentro del MoneyContainer,
        /// tiene el valor que acepta el container.
        /// </summary>
        /// <param name="moneyContainer">Container tipo <see cref="MoneyContainer"/>.</param>
        /// <param name="money">DraggableItem tipo <see cref="Money"/>.</param>
        /// <returns>Bool si el valor es correcto o no.</returns>
        public static bool VerifyOperation(MoneyContainer moneyContainer, Money money)
        {
            return moneyContainer.AcceptableValue == money.Value;
        }
    }
}