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
        public List<Atributos> Atributos { get; set; }
        public Tag(string nombre, List<Atributos> atributos)
        {
            this.Nombre = nombre;
            this.Atributos = atributos;
        }
        public Tag(string nombre)
        {
            this.Nombre = nombre;
        }

        // Metodo que retorna todos los atributos de un tag.
        public string RetornarAtributos()
        {
            string atributos = "";
            foreach (Atributos Atr in this.Atributos)
            {
                atributos += Atr.Clave + "=" + Atr.Valor + "\n";
            }
            return atributos;
        }
    }
}