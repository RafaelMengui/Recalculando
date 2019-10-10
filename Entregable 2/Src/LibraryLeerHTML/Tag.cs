using System.Collections.Generic;

namespace Proyecto.LeerHTML
{
    /// <summary>
    /// Clase Tag.
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Nombre del Tag.
        /// </summary>
        private string nombre;

        /// <summary>
        /// Lista que contiene objetos Atributos.
        /// </summary>
        private List<Atributos> atributos;
    
        /// <summary>
        /// Constructor de Tag.
        /// </summary>
        /// <param name="nombre">String Nombre del Tag</param>
        /// <param name="atributos">Lista de objetos atributos pertenecientes al tag.</param>
        public Tag(string nombre, List<Atributos> atributos)
        {
            this.Nombre = nombre;
            this.Atributos = atributos;
        }

        /// <summary>
        /// Gets or Sets del nombre del tag.
        /// </summary>
        /// <value>String nombre.</value>
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nombre = value;
                }
            }
        }

        /// <summary>
        /// Lista de todos los Objetos Atributos del Tag.
        /// </summary>
        /// <value>Lista de Objetos Atributos.</value>
        public List<Atributos> Atributos { get; set; }

        /// <summary>
        /// Metodo que retorna un string de los atributos de un tag en formato "clave=valor".
        /// </summary>
        /// <returns>string "clave=valor"</returns>
        public string RetornarAtributos()
        {
            string atributos = "";
            foreach (Atributos atr in this.Atributos)
            {
                atributos += atr.Clave + "=" + atr.Valor + "\n";
            }
            return atributos;
        }
    }
}