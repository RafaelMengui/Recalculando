using System;
using System.Collections;

namespace src
{
    class Program
    {
        static void Main()
        {
            ArrayList Lineas = Filtro.FiltrarTexto(LeerLineas.RetornarLineas());
            foreach (Tag T in Lineas)
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

    Tag -> Formato_impresino -> Impresion.
*/
