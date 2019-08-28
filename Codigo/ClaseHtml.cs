using System;
using System.IO;
using System.Collections;

namespace Interpretar_HTML
{
    public class Etiqueta
    {
        public Etiqueta(string NombreTag, string Atributo, string Contenido)
        {
            this.NombreTag = nombretag;
            this.Atributo = atributo;
            this.Contenido = contenido;
        }

        private string nombretag;
        private string atributo;
        private string contenido;

        public string NombreTag { get; set; }
        public string Atributo { get; set; }
        public string Contenido { get; set; }
    }
}