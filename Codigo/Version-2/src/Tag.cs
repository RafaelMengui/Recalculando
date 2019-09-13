using System;
using System.Collections;
using System.Collections.Generic;

namespace Version2
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

        // Metodo que imprime todos los atributos de un tag.
        public void ImprimirAtributos()
        {
            foreach (Atributos Atr in this.Atributos)
            {
                Console.WriteLine(Atr.Clave + "=" + Atr.Valor);
            }
        }
    }
}