using System;
using System.Collections.Generic;
using System.Text;
using Proyecto.LeerHTML;

namespace Proyecto
{
    /// <summary>
    /// Una caneria a traves de la cual pasa una imagen.
    /// </summary>
    public interface IPipe
    {        
        /// <summary>
        /// Envia la imagen a traves de la caneria.
        /// </summary>
        /// <param name="picture">la imagen a enviar</param>
        Tag Send(Tag tag);

    }
}
