using System;
using System.Collections.Generic;

namespace Version2
{
    class Program
    {
        static void Main()
        {
            const string ArchivoHTML = @"..\..\..\..\..\HTML-Prueba\test2.html";
            List<Tag> Tags = Filtro.FiltrarHTML(LeerHTML.RetornarHTML(ArchivoHTML));

            foreach (Tag T in Tags)
            {
                Console.WriteLine(T.Nombre);
                T.ImprimirAtributos();
            }
        }
    }
}
/*
- Clase Atributo: Los atributos sera clave/valor.
- Clase tag: atributos -> nombre tag/array atributos.
- Clase imprimir: Para cambiar destino de impresion.
- Clase Formato_impresion: La razon de cambio debe ser el tipo de formato que se va a imprimir.

    Tag -> Formato_impresion -> Impresion.

Para acceder al nombre de un determinado Tag:
    Tags[n].Nombre

Para acceder a un determinado atributo de un tag:
    Tags[n].Atributos[i].Clave;
    Tags[n].Atributos[i].Valor;
*/
