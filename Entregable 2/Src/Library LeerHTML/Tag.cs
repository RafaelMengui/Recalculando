using System;
using System.Collections;
using System.Collections.Generic;

namespace LeerHTML
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
        public List<Atributos> atributos { get; set; }
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