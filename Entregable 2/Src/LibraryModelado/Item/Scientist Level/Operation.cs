using System.Collections.Generic;
using Proyecto.LibraryModelado;
namespace Proyecto.Item.ScientistLevel
{
    /// <summary>
    /// Una operacion es un conjunto de containers que representan cada parte de una operacion.
    /// Consta de un container para cada operando, uno en donde se coloque la imagen de suma o resta,
    /// dependiendo de la operacion, y un container en donde se colocara el item que represente el resultado
    /// de la operacion.
    /// </summary>
    public class Operation : IComponent
    {
        /// <summary>
        /// Instancia del mundo.
        /// </summary>
        private World world = Singleton<World>.Instance;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="level">Nivel al que pertenece la operacion.</param>
        /// <param name="operand1">Container en donde se colocara el operando 1 de la ecuacion.</param>
        /// <param name="operationType">Container en donde se colocara la imagen de suma o resta.</param>
        /// <param name="operand2">Container en donde se colocara el operando 2 de la ecuacion.</param>
        /// <param name="resultContainer">Container en donde se colocara el resultado de la operacion.</param>
        public Operation(Space level, MoneyContainer resultContainer)
        {
            this.Operands = new List<MoneyContainer>();
            this.ResultContainer = resultContainer;
            this.Level = level;
        }

        /// <summary>
        /// Gets or sets del nivel al que pertenece la operacion.
        /// </summary>
        /// <value></value>
        public Space Level { get; set; }

        public string ID { get; set; }

        /// <summary>
        /// Gets or sets del operando 1.
        /// </summary>
        /// <value></value>
        public List<MoneyContainer> Operands { get; }

        /// <summary>
        /// Gets or sets del container en donde se va a soltar el operando del resultado.
        /// </summary>
        /// <value></value>
        public MoneyContainer ResultContainer { get; set; }
    }
}