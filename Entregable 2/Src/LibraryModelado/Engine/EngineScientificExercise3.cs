//--------------------------------------------------------------------------------
// <copyright file="EngineScientificExercise3.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
using Proyecto.Item.ScientistLevel;
using Proyecto.Item;

namespace Proyecto.LibraryModelado.Engine
{
    /// <summary>
    /// Clase EngineScientificExercise3, responsable de implementar la logica del nivel scientific ejercicio 3.
    /// </summary>
    public class EngineScientificExercise3 : IEngine, ILevelEngine
    {
        /// <summary>
        /// Variable Level utilizada para instanciar un nivel asignable.
        /// </summary>
        private Space level;

        /// <summary>
        /// Instancia unica del motor general.
        /// </summary>
        private EngineGame engineGame = Singleton<EngineGame>.Instance;

        private Feedback levelFeedback;

        /// <summary>
        /// Constructor.
        /// </summary>
        public EngineScientificExercise3()
        {
            this.ResultsOfLevel = new bool[2];
            this.LevelCounter = 0;
            this.FeedbackList = new List<Feedback>();
        }

        public List<Feedback> FeedbackList { get; }

        public Space Level { get; set; }


        /// <summary>
        /// Gets or sets de la etiqueta de texto utilizado para especificar si la accion fue correcta o incorrecta.
        /// </summary>
        /// <value>Etiqueta <see cref="Label"/>.</value>
        public Label Feedback { get; set; }

        /// <summary>
        /// Gets or sets de contador utilizado para saber en que pagina del nivel nos encontramos.
        /// Existen dos paginas en el nivel.
        /// </summary>
        /// <value>Int.</value>
        public int LevelCounter { get; private set; }

        /// <summary>
        /// Gets or sets de los resultados del nivel.
        /// Por predeterminado los cuatro parametros son False.
        /// true = Completo una pagina correctamente.
        /// false = No contesto bien la pregunta.
        /// </summary>
        /// <value>Array de Bools.</value>
        public bool[] ResultsOfLevel { get; private set; }
        public Feedback LevelFeedback { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        /// <summary>
        /// Verifica que se hayan completado las cuatro paginas del nivel.
        /// </summary>
        /// <returns>Bool.</returns>
        public bool VerifyWinLevel()
        {
            return this.ResultsOfLevel[0] && this.ResultsOfLevel[1];
        }

        /// <summary>
        /// Metodo que se utiliza para verificar la opcion selccionada.
        /// Si esta bien contestada, el bool de la pagina (this.ResultsOfLevel) pasa a ser true, y el
        /// level counter suma 1.
        /// </summary>
        public bool VerifyQuestion(ButtonTrueFalse button)
        {
            if (button.Value)
            {
                this.ResultsOfLevel[this.LevelCounter] = true;
                this.LevelCounter += 1;
                this.GoodFeedback();
                return true;
            }
            else
            {
                this.BadFeedback();
                return false;
            }
        }

        /// <summary>
        /// Metodo utilizado para iniciar o reiniciar el motor del nivel.
        /// </summary>
        public void StartLevel()
        {
            this.ResultsOfLevel = new bool[2];
            this.LevelCounter = 0;
            this.Feedback = this.CreateFeedback();
        }

        /// <summary>
        /// Metodo responsable de crear la etiqueta de texto que servira de feedback a las acciones realizadas.
        /// </summary>
        /// <returns>Etiqueta <see cref="Label"/>.</returns>
        public Label CreateFeedback()
        {
            foreach (var space in this.engineGame.LevelEngines)
            {
                if (space.Value is EngineScientificExercise3)
                {
                    this.level = space.Key;
                }
            }

            Label feedback = new Label("Feedback3", this.level, 600, 240, 100, 50, "Vacio.png", string.Empty);
            this.level.ItemList.Add(feedback);
            return feedback;
        }

        /// <summary>
        /// Metodo que asigna al texto un buen feedback. Utilizado cuando la accion realizada es correcta.
        /// </summary>
        public bool GoodFeedback()
        {
            this.Feedback.Text = "Excelente!";
            //this.engineGame.UpdateFeedback(this.LevelFeedback);
            return true;
        }

        /// <summary>
        /// Metodo que asigna al texto un mal feedback. Utilizado cuando la accion realizada es incorrecta.
        /// </summary>
        public bool BadFeedback()
        {
            this.Feedback.Text = "Intentalo de nuevo!";
            //this.engineGame.UpdateFeedback(this.LevelFeedback);
            return true;
        }

        /// <summary>
        /// Sobrescribe el metodo abstracto de <see cref="IEngine"/>, en donde se recorre el diccionario
        /// de motores asociados a niveles (EngineGame.LevelEngines), para reconocer en que nivel
        /// se debe crear el boton que mostrara la pagina principal al ejecutarlo.
        /// </summary>
        public IComponent ButtonGoToMain()
        {
            foreach (var space in this.engineGame.LevelEngines)
            {
                if (space.Value is EngineScientificExercise3)
                {
                    this.level = space.Key;
                }
            }

            Items goToMain = new ButtonGoToPage("Scientific3ToMain", this.level, -890, 345, 125, 125, "GoToMain.png", "#FCFCFC", "MainPage");
            this.level.ItemList.Add(goToMain);
            return goToMain;
        }

        public void ButtonGoToNextLevel()
        {
            foreach (var space in this.engineGame.LevelEngines)
            {
                if (space.Value is EngineScientificExercise3)
                {
                    this.level = space.Key;
                }
            }

            Items goToNext = new ButtonGoToPage("Scientific3ToMainPage", this.level, 0, 0, 200, 150, "huevo.png", "#FCFCFC", "MainPage");
            this.level.ItemList.Add(goToNext);
            this.engineGame.CreateInUnity(goToNext);
        }
        public void SetFeedback(Feedback feedback)
        {}
    }
}