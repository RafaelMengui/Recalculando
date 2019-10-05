using Proyecto;
using Proyecto.LeerHTML;

namespace Proyecto.Pipes
{
    public class PipeConditional : IPipe
    {
        IPipe truePipe, falsePipe;
        IFilterConditional filter;

        /// <summary>
        /// Pipe condicional, si se cumple una condicion manda por un pipe, en caso contrario por otro.
        /// </summary>
        /// <param name="filter">Filtro a aplicar.</param>
        /// <param name="truePipe">Proximo pipe si la condicion es Verdadera.</param>
        /// <param name="falsePipe">Proximo pipe si la condicion es Falsa.</param>
        public PipeConditional(IFilterConditional filter, IPipe truePipe, IPipe falsePipe)
        {
            this.truePipe = truePipe;
            this.falsePipe = falsePipe;
            this.filter = filter;
        }

        /// <summary>
        /// Metodo Send: evalua la condicion y envia al proximo pipe.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>Devuelve tag, despues de realizado el filtro.</returns>
        public Tag Send(Tag tag)
        {
            Tag resultTag;
            resultTag = filter.Creator(tag);
            if (filter.Result)
            {
                resultTag = truePipe.Send(resultTag);
            }
            else 
            {
                resultTag = falsePipe.Send(resultTag);
            }
            return resultTag;
        }
    }
}