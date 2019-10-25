namespace Proyecto.LibraryModelado.Engine
{
    /// <summary>
    /// Motor general
    /// </summary>
    public class EngineGame
    {
        private EngineScientific engineScientific = Singleton<EngineScientific>.Instance;

        /// <summary>
        /// Pagina principal del juego, el motor la conoce para poder viajar a ella en cualquier momento.
        /// </summary>
        private Space mainPage;

        /// <summary>
        /// Constructor.
        /// </summary>
        public EngineGame()
        {
            this.MainPage = mainPage;
        }

        /// <summary>
        /// Gets or sets de la pagina principal.
        /// </summary>
        /// <value></value>
        public Space MainPage { get; set; }
    }
}