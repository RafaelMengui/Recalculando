//--------------------------------------------------------------------------------
// <copyright file="EngineScientificExercise2.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Item;
using System.Collections.Generic;
using Proyecto.Item.ScientistLevel;

namespace Proyecto.LibraryModelado.Engine
{
    /// <summary>
    /// Clase EngineScientificExercise2, responsable de implementar la logica del nivel scientific ejercicio 2.
    /// </summary>
    public class EngineScientificExercise4 : IEngine, ILevelEngine
    {
        /// <summary>
        /// Variable Level utilizada para instanciar un nivel asignable.
        /// </summary>
        private Space level;

        /// <summary>
        /// Instancia unica del motor general.
        /// </summary>
        private EngineGame engineGame = Singleton<EngineGame>.Instance;

        /// <summary>
        /// Objeto de tipo <see cref="Feedback"/> que mostrara por pantalla textos para interactuar con el usuario.
        /// </summary>
        private Feedback levelFeedback;

        /// <summary>
        /// Boton que al apretarlo aparecera la pantalla principal.
        /// </summary>
        private ButtonGoToPage buttonGoToMain;

        /// <summary>
        /// Constructor del motor.
        /// </summary>
        public EngineScientificExercise4()
        {
            this.Level = this.level;
            this.ResultsOfLevel = new bool[2];
            this.OperationCounter = 0;
            this.LevelFeedback = this.levelFeedback;
            this.ButtonGoToMain = this.buttonGoToMain;
            this.Operations = new List<Operations>();
        }

        /// <summary>
        /// Gets or sets Boton que al apretarlo aparecera la pantalla principal.
        /// </summary>
        public ButtonGoToPage ButtonGoToMain { get; set; }

        /// <summary>
        /// Gets de lista de operaciones del nivel
        /// </summary>
        public List<Operations> Operations { get; }

        /// <summary>
        /// Gets or sets del nivel asociado a este Motor.
        /// </summary>
        /// <value>Level.</value>
        public Space Level { get; set; }

        /// <summary>
        /// Gets or sets de contador utilizado para saber en que pagina del nivel nos encontramos.
        /// Existen dos paginas en el nivel.
        /// </summary>
        /// <value>Int.</value>
        public int OperationCounter { get; private set; }

        /// <summary>
        /// Gets or sets de los resultados del nivel.
        /// Por predeterminado los dos parametros son False.
        /// true = Completo una operacion correctamente.
        /// false = No contesto bien la pregunta.
        /// </summary>
        /// <value>Array de Bools.</value>
        public bool[] ResultsOfLevel { get; private set; }

        /// <summary>
        /// Gets or sets del Feedback asociado al motor.
        /// </summary>
        /// <value>Feedback.</value>
        public Feedback LevelFeedback { get; set; }

        /// <summary>
        /// Metodo utilizado para iniciar o reiniciar el motor del nivel.
        /// </summary>
        public void StartLevel()
        {
            string text = "Hola! En este juego deberas seleccionar la respuesta correcta.";
            if (this.buttonGoToMain is null)
            {
                this.CreateButtonGoToMain();
            }
            if (this.LevelFeedback is null)
            {
                this.CreateFeedback();
            }

            this.engineGame.UpdateFeedback(this.LevelFeedback, text);
            this.ResultsOfLevel = new bool[2];
            this.OperationCounter = 0;
        }

        /// <summary>
        /// Verifica que se hayan completado las dos preguntas del nivel.
        /// </summary>
        /// <returns>Bool.</returns>
        public bool VerifyWinLevel()
        {
            if (this.ResultsOfLevel[0] && this.ResultsOfLevel[1])
            {
                string text = "Excelente! Has contestado correctamente las dos preguntas. Puedes continuar al siguiente nivel.";
                this.engineGame.UpdateFeedback(this.LevelFeedback, text);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Metodo que se utiliza para verificar que se responda la pregunta de forma correcta.
        /// Si esta bien contestada, el bool de la pagina (this.ResultsOfLevel) pasa a ser true, y el
        /// level counter suma 1.
        /// </summary>
        /// <param name="button">Boton seleccionado.</param>
        /// <returns>Bool si el boton es correcto.</returns>
        public bool VerifyExercise(ButtonTrueFalse button)
        {
            if (button.Value)
            {
                this.ResultsOfLevel[this.OperationCounter] = true;
                this.OperationCounter += 1;
                this.GoodFeedback();
                this.VerifyWinLevel();

                foreach (Operations operation in this.Operations)
                {
                    if (operation.Components.Contains(button))
                    {
                        foreach (Items item in operation.Components)
                        {
                            (item as ButtonTrueFalse).Pushable = false;
                        }
                    }
                }
                return true;
            }
            else
            {
                this.BadFeedback();
                return false;
            }
        }

        /// <summary>
        /// Metodo que asigna al texto un buen feedback. Utilizado cuando la accion realizada es correcta.
        /// </summary>
        public void GoodFeedback()
        {
            string text = "Excelente trabajo! Puedes continuar al siguiente nivel.";
            this.engineGame.UpdateFeedback(this.LevelFeedback, text);
        }

        /// <summary>
        /// Metodo que asigna al texto un mal feedback. Utilizado cuando la accion realizada es incorrecta.
        /// </summary>
        public void BadFeedback()
        {
            string text = "Intentalo de nuevo ¡Tu puedes!";
            this.engineGame.UpdateFeedback(this.LevelFeedback, text);
        }

        /// <summary>
        /// Metodo responsable de asignarle al motor, su respectivo objeto feedback.
        /// </summary>
        public void CreateFeedback()
        {
            Feedback feedback = new Feedback("Feedback4", this.Level, 710, 70, 320, 400, "Vacio.png", string.Empty, 30, true, false);
            this.engineGame.CreateInUnity(feedback);
            this.LevelFeedback = feedback;
        }

        /// <summary>
        /// Sobrescribe el metodo abstracto de <see cref="IEngine"/>, crea el boton que mostrara la pagina principal al ejecutarlo.
        /// </summary>
        public void CreateButtonGoToMain()
        {
            ButtonGoToPage goToMain = new ButtonGoToPage("Scientific4ToMain", this.Level, -890, 470, 125, 125, "GoToMain.png", "#FCFCFC", "MainPage");
            this.Level.ItemList.Add(goToMain);
            this.engineGame.CreateInUnity(goToMain);
            this.ButtonGoToMain = goToMain;
        }
    }
}