//--------------------------------------------------------------------------------
// <copyright file="FactoryOperation.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Linq;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;
using Proyecto.Item.ScientistLevel;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de crear objetos Operation.
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryOperation : IFactoryComponent
    {
        /// <summary>
        /// Instancia del mundo.
        /// </summary>
        private World world = Singleton<World>.Instance;

        /// <summary>
        /// Nivel al que pertenece la operacion.
        /// </summary>
        private Space level;

        /// <summary>
        /// Nombre del operando 1.
        /// </summary>
        private string operandsName;

        /// <summary>
        /// Nombre del operando 2.
        /// </summary>
        private string operand2Name;

        /// <summary>
        /// Nombre del container que contendra el resultado.
        /// </summary>
        private string resultContainerName;

        /// <summary>
        /// Operando 1.
        /// </summary>
        private MoneyContainer operands;

        /// <summary>
        /// Operando 2.
        /// </summary>
        private MoneyContainer operand2;

        /// <summary>
        /// Container que contendra el resultado.
        /// </summary>
        private MoneyContainer resultContainer;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryComponent.
        /// Tiene la responsabilidad de crear el componente de tipo <see cref="Operation"/>.
        /// </summary>
        /// <param name="tag">Tag <see cref="Tag"/>.</param>
        /// <returns>Componente <see cref="IComponent"/>.</returns>
        public override IComponent MakeComponent(Tag tag)
        {
            this.level = this.world.SpaceList.Last();
            this.operandsName = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Operands"; }).Valor;
            this.resultContainerName = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Result"; }).Valor;
            this.resultContainer = this.level.ItemList.Find(delegate(Items item) {return item.Name == this.resultContainerName;}) as MoneyContainer;
            Operation operation = new Operation(this.level, this.resultContainer);

            foreach (string operands in this.operandsName.Split(','))
            {
                this.operands = this.level.ItemList.Find(delegate(Items item) {return item.Name == operands;}) as MoneyContainer;
                operation.Operands.Add(this.operands);
            }

            return operation;
        }
    }
}