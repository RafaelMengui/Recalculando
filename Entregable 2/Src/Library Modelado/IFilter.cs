using System;

namespace Proyecto
{
    /// <summary>
    /// Un filtro grafico.
    /// </summary>
    /// <remarks>
    /// Un filtro Crea un objeto Item y llama al metodo build de unity
    /// </remarks>
    public interface IFilter
    {
        IPicture Filter(IPicture image);
    }
}
