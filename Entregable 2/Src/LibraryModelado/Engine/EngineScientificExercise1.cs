//--------------------------------------------------------------------------------
// <copyright file="EngineScientificExercise1.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
using Proyecto.Item;
using Proyecto.Item.ScientistLevel;

namespace Proyecto.LibraryModelado.Engine
{
    /// <summary>
    /// Clase EngineScientificExercise1, responsable de implementar la logica del ejercicio 1 del nivel scientific.
    /// Hereda de las clases abstractas <see cref="IEngine"/> y <see cref="ILevelEngine"/>.
    /// </summary>
    public class EngineScientificExercise1 : IEngine, ILevelEngine
    {
        /// <summary>
        /// Variable Level utilizada para instanciar un nivel asignable.
        /// </summary>
        private Space level;

        /// <summary>
        /// Objeto de tipo <see cref="Feedback"/> que mostrara por pantalla textos para interactuar con el usuario.
        /// </summary>
        private Feedback levelFeedback;

        /// <summary>
        /// Instancia unica del motor general.
        /// </summary>
        private EngineGame engineGame = Singleton<EngineGame>.Instance;

        /// <summary>
        /// Constructor del motor.
        /// </summary>
        public EngineScientificExercise1()
        {
            this.Level = this.level;
            this.ResultsOfLevel = new bool[3];
            this.LevelFeedback = this.levelFeedback;
            this.Operations = new List<Operations>();
        }

        /// <summary>
        /// Gets de lista de operaciones del nivel.
        /// </summary>
        /// <value>Lista de operacions.</value>
        public List<Operations> Operations { get; }

        /// <summary>
        /// Gets or sets del Feedback asociado al motor.
        /// </summary>
        /// <value>Feedback.</value>
        public Feedback LevelFeedback { get; set; }

        /// <summary>
        /// Gets or sets del nivel asociado a este Motor.
        /// </summary>
        /// <value>Level.</value>
        public Space Level { get; set; }

        /// <summary>
        /// Gets or sets de contador utilizado para saber en que operacion de la pagina nos encontramos.
        /// Existen dos operaciones dentro de la pagina.
        /// </summary>
        /// <value>Int.</value>
        public int OperationCounter { get; private set; }

        /// <summary>
        /// Gets or sets de los resultados del nivel.
        /// Por predeterminado los dos parametros son False.
        /// true = Completo una pagina correctamente (los dos parametros de this.ResultsOfPage son true).
        /// false = No completo las dos operaciones de la pagina.
        /// </summary>
        /// <value>Array de Bools.</value>
        public bool[] ResultsOfLevel { get; private set; }

        /// <summary>
        /// Metodo utilizado para iniciar o reiniciar el motor del juego.
        /// </summary>
        public void StartLevel()
        {
            this.ResultsOfLevel = new bool[3];
            this.OperationCounter = 0;
        }

        /// <summary>
        /// Metodo responsable de asignarle al motor, su respectivo objeto feedback.
        /// </summary>
        /// <param name="feedback">Feedback.</param>
        public void SetFeedback(Feedback feedback)
        {
            this.LevelFeedback = feedback;
            this.LevelFeedback.Text = "Hola! En este juego deberas completar la suma, arrastrando el dinero correcto.";
            this.engineGame.UpdateFeedback(this.LevelFeedback);
        }

        /// <summary>
        /// Metodo responsable de verificar si el objeto tipo Money soltado dentro del MoneyContainer,
        /// tiene el valor que acepta el container.
        /// </summary>
        /// <param name="moneyContainer">Container tipo <see cref="MoneyContainer"/>.</param>
        /// <param name="money">DraggableItem tipo <see cref="Money"/>.</param>
        /// <returns>Bool si el valor es correcto o no.</returns>
        public bool VerifyOperation(MoneyContainer moneyContainer, Money money)
        {
            return moneyContainer.AcceptableValue == money.Value;
        }

        /// <summary>
        /// Verifica que se hayan completado las tres operaciones del nivel.
        /// </summary>
        /// <returns>Bool.</returns>
        public bool VerifyWinLevel()
        {
            if (this.ResultsOfLevel[0] && this.ResultsOfLevel[1] && this.ResultsOfLevel[2])
            {
                this.LevelFeedback.Text = "Bien Hecho! has contestado correctamente las tres preguntas. Puedes continuar al siguiente nivel.";
                this.engineGame.UpdateFeedback(this.LevelFeedback);
                this.ButtonGoToNextLevel();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Metodo que se utiliza para verificar que este correctamente realizada una de las operaciones.
        /// Si esta bien hecha la operacion, el bool (en this.ResultsOfPage) asociado a la parte del nivel pasa a ser true.
        /// Al contador se le suma 1, y el container del money, pasa a ser el container en donde es dropeado.
        /// </summary>
        /// <param name="moneyContainer">Container de dinero en donde es soltado el dinero.</param>
        /// <param name="money">Dinero arrastrado.</param>
        /// <returns>Bool si el dinero soltado es correcto.</returns>
        public bool VerifyExercise(MoneyContainer moneyContainer, Money money)
        {
            if (this.VerifyOperation(moneyContainer, money))
            {
                this.ResultsOfLevel[this.OperationCounter] = true;
                this.OperationCounter += 1;
                money.Draggable = false;
                this.GoodFeedback();
                this.VerifyWinLevel();
                return true;
            }

            else
            {
                if (moneyContainer.AcceptableValue == 0)
                {
                    money.Container = moneyContainer;
                    return true;
                }

                else if (moneyContainer.AcceptableValue != -1)
                {
                    this.BadFeedback();
                }

                return false;
            }
        }

        /// <summary>
        /// Metodo que asigna al texto un buen feedback. Utilizado cuando la accion realizada es correcta.
        /// </summary>
        public bool GoodFeedback()
        {
            this.LevelFeedback.Text = "Muy buen trabajo, ¡Continua asi!";
            this.engineGame.UpdateFeedback(this.LevelFeedback);
            return true;
        }

        /// <summary>
        /// Metodo que asigna al texto un mal feedback. Utilizado cuando la accion realizada es incorrecta.
        /// </summary>
        public bool BadFeedback()
        {
            this.LevelFeedback.Text = "Esa suma no es correcta, ¡Intentalo de nuevo!";
            this.engineGame.UpdateFeedback(this.LevelFeedback);
            return true;
        }

        /// <summary>
        /// Sobrescribe el metodo abstracto de <see cref="IEngine"/>, crea el boton que mostrara la pagina principal al ejecutarlo.
        /// </summary>
        public IComponent ButtonGoToMain()
        {
            Items goToMain = new ButtonGoToPage("Scientific1ToMain", this.Level, -890, 345, 125, 125, "GoToMain.png", "#FCFCFC", "MainPage");
            this.Level.ItemList.Add(goToMain);
            return goToMain;
        }

        /// <summary>
        /// Este boton aparecera en pantalla al terminar un nivel, al ejecutarlo ira a la proxima pantalla del nivel scientific.
        /// </summary>
        public void ButtonGoToNextLevel()
        {
            Items goToNext = new ButtonGoToPage("Scientific1ToScientific2", this.Level, 0, 0, 200, 150, "huevo.png", "#FCFCFC", "ScientificExercise2");
            this.Level.ItemList.Add(goToNext);
            this.engineGame.CreateInUnity(goToNext);
        }
    }
}