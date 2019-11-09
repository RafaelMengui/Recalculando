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
    public class EngineScientificExercise2 : IEngine, ILevelEngine
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
        /// Constructor del motor.
        /// </summary>
        public EngineScientificExercise2()
        {
            this.Level = this.level;
            this.ResultsOfLevel = false;
            this.Operations = new List<Operations>();
            this.LevelFeedback = this.levelFeedback;
        }

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
        /// Gets or sets de los resultados del nivel.
        /// Por predeterminado los dos parametros son False.
        /// true = Completo una operacion correctamente.
        /// false = No contesto bien la pregunta.
        /// </summary>
        /// <value>Array de Bools.</value>
        public bool ResultsOfLevel { get; private set; }

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
            this.ResultsOfLevel = false;
            foreach (Operations operation in this.Operations)
            {
                foreach (Items item in operation.Components)
                {
                    (item as ButtonTrueFalse).Pushable = true;
                }
            }
        }

        /// <summary>
        /// Metodo responsable de asignarle al motor, su respectivo objeto feedback.
        /// </summary>
        /// <param name="feedback">Feedback.</param>
        public void SetFeedback(Feedback feedback)
        {
            this.LevelFeedback = feedback;
            this.LevelFeedback.Text = "Hola! En este juego deberas seleccionar la opcion correcta a la pregunta.";
            this.engineGame.UpdateFeedback(this.LevelFeedback);
        }

        /// <summary>
        /// Verifica que se hayan completado las dos preguntas del nivel.
        /// </summary>
        /// <returns>Bool.</returns>
        public bool VerifyWinLevel()
        {
            if (this.ResultsOfLevel)
            {
                this.ButtonGoToNextLevel();
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
                this.ResultsOfLevel = true;
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
        public bool GoodFeedback()
        {
            this.LevelFeedback.Text = "Excelente trabajo! Puedes continuar al siguiente nivel.";
            this.engineGame.UpdateFeedback(this.LevelFeedback);
            return true;
        }

        /// <summary>
        /// Metodo que asigna al texto un mal feedback. Utilizado cuando la accion realizada es incorrecta.
        /// </summary>
        public bool BadFeedback()
        {
            this.LevelFeedback.Text = "Intentalo de nuevo ¡Tu puedes!";
            this.engineGame.UpdateFeedback(this.LevelFeedback);
            return true;
        }

        /// <summary>
        /// Sobrescribe el metodo abstracto de <see cref="IEngine"/>, crea el boton que mostrara la pagina principal al ejecutarlo.
        /// </summary>
        public IComponent ButtonGoToMain()
        {
            Items goToMain = new ButtonGoToPage("Scientific2ToMain", this.Level, -890, 470, 125, 125, "GoToMain.png", "#FCFCFC", "MainPage");
            this.Level.ItemList.Add(goToMain);
            return goToMain;
        }

        /// <summary>
        /// Este boton aparecera en pantalla al terminar un nivel, al ejecutarlo ira a la proxima pantalla del nivel scientific.
        /// </summary>
        public void ButtonGoToNextLevel()
        {
            Items goToNext = new ButtonStartLevel("Scientific2ToScientific3", this.Level, 0, 0, 500, 300, "siguienteNivel.png", "#FCFCFC", "ScientificExercise3");
            this.Level.ItemList.Add(goToNext);
            this.engineGame.CreateInUnity(goToNext);
        }
    }
}