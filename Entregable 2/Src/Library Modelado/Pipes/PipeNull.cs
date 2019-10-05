using Proyecto.LeerHTML;

namespace Proyecto.Pipes
{
    public class PipeNull : IPipe
    {
        Tag tag;
        /// <summary>
        /// Recibe un Tag(inTag), lo guarda en una variable tag y lo retorna.
        /// </summary>
        /// <param name="inTag">Tag a recibir</param>
        /// <returns>El mismo tag</returns>
        public Tag Send(Tag inTag)
        {
            this.tag = inTag;
            return this.tag;
        }
    }
}