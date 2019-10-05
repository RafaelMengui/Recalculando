using LeerHTML;
namespace Proyecto
{
    /// <summary>
    /// Un filtro de objetos.
    /// </summary>
    /// <remarks>
    /// Un filtro Crea un objeto Item y llama al metodo build de unity
    /// </remarks>
    public interface IFilter
    {
        Tag Creator(Tag tag);
    }
}
