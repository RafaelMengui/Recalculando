using System;
using System.Collections;
using System.Collections.Generic;

namespace src
{
    class Program
    {
        static void Main()
        {
            const string Archivo = @"..\..\..\..\..\HTML-Prueba\test.html";

            List<Tag> tags = Filtro.FiltrarTexto(LeerLineas.RetornarLineas(Archivo));

            foreach (Tag T in tags)
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
*/
