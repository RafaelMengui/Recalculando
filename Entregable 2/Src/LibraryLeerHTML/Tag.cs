using System;
using System.Collections;
using System.Collections.Generic;

namespace Proyecto.LeerHTML
{
    public class Tag
    {
        private string nombre;
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
        /// <value>List<Atributos></value>
        public List<Atributos> atributos { get; set; }

        /// <summary>
        /// Constructor de Tag.
        /// </summary>
        /// <param name="nombre">string Nombre del Tag</param>
        /// <param name="atributos">Lista de objetos atributos pertenecientes al tag.</param>
        public Tag(string nombre, List<Atributos> atributos)
        {
            this.nombre = nombre;
            this.atributos = atributos;
        }

        /// <summary>
        /// Retorna un string de los atributos de un tag en formato "clave=valor".
        /// </summary>
        /// <returns></returns>
        public string RetornarAtributos()
        {
            string atributos = "";
            foreach (Atributos atr in this.atributos)
            {
                atributos += atr.clave + "=" + atr.valor + "\n";
            }
            return atributos;
        }
    }
}