using Proyecto.Item.ScientistLevel;
using Xunit;

namespace Proyecto.LibraryModelado.Engine.test
{
    public class UnitTextScientificExercise2
    {
        private Level level = new Level("level", null);
        private EngineScientificExercise3 engineScientific3 = Singleton<EngineScientificExercise3>.Instance;

        [Fact]
        public void VerifyCorrectAnswer()
        {
            ButtonTrueFalse correctButton = new ButtonTrueFalse("correcto", this.level, 20, 202, 202, 20, null, "#FCFCFC", true);
            this.engineScientific3.StartLevel();
            Assert.Equal(true, engineScientific3.VerifyQuestion(correctButton));
        }

        [Fact]
        public void VerifyIncorrectAnswer()
        {
            ButtonTrueFalse incorrectButton = new ButtonTrueFalse("incorrecto", this.level, 20, 202, 202, 20, null, "#FCFCFC", false);
            this.engineScientific3.StartLevel();
            Assert.Equal(false, engineScientific3.VerifyQuestion(incorrectButton));
        }

        [Fact]
        public void VerifyWin()
        {
            this.engineScientific3.StartLevel();
            ButtonTrueFalse correctButtonPage1 = new ButtonTrueFalse("correct1", this.level, 20, 202, 202, 20, null, "#FCFCFC", true);
            ButtonTrueFalse incorrectButton1Page1 = new ButtonTrueFalse("incorrecto1", this.level, 20, 202, 202, 20, null, "#FCFCFC", false);
            ButtonTrueFalse incorrectButton2Page1 = new ButtonTrueFalse("incorrecto2", this.level, 20, 202, 202, 20, null, "#FCFCFC", false);
            if (engineScientific3.VerifyQuestion(correctButtonPage1))
            {
                ButtonTrueFalse correctButtonPage2 = new ButtonTrueFalse("correcto2", this.level, 20, 202, 202, 20, null, "#FCFCFC", true);
                ButtonTrueFalse incorrectButton1Page2 = new ButtonTrueFalse("incorrecto3", this.level, 20, 202, 202, 20, null, "#FCFCFC", false);
                ButtonTrueFalse incorrectButton2Page2 = new ButtonTrueFalse("incorrecto4", this.level, 20, 202, 202, 20, null, "#FCFCFC", false);
                if (engineScientific3.VerifyQuestion(correctButtonPage2))
                {
                    ButtonTrueFalse correctButtonPage3 = new ButtonTrueFalse("correcto3", this.level, 20, 202, 202, 20, null, "#FCFCFC", true);
                    ButtonTrueFalse incorrectButton1Page3 = new ButtonTrueFalse("incorrecto5", this.level, 20, 202, 202, 20, null, "#FCFCFC", false);
                    ButtonTrueFalse incorrectButton2Page3 = new ButtonTrueFalse("incorrecto6", this.level, 20, 202, 202, 20, null, "#FCFCFC", false);
                    if (engineScientific3.VerifyQuestion(correctButtonPage3))
                    {
                        ButtonTrueFalse correctButtonPage4 = new ButtonTrueFalse("correcto4", this.level, 20, 202, 202, 20, null, "#FCFCFC", true);
                        ButtonTrueFalse incorrectButton1Page4 = new ButtonTrueFalse("incorrecto7", this.level, 20, 202, 202, 20, null, "#FCFCFC", false);
                        ButtonTrueFalse incorrectButton2Page4 = new ButtonTrueFalse("incorrecto8", this.level, 20, 202, 202, 20, null, "#FCFCFC", false);
                        engineScientific3.VerifyQuestion(correctButtonPage4);
                    }
                }
            }
            Assert.Equal(true, engineScientific3.VerifyWinLevel());
        }
    }
}
