Reecalculando: 
Nuestro juego pensando especialmente para personas que padecen dislculía.
El juego en general se basa en 4 personajes, cada uno de estos equivale a un juego. 
Para esta entrega los juegos planteados son:
°Cientifico: El niño debe realizar las sumas pedidas, arrastrando los billetes. 



















-PATRONES:

1. Creator 
Esta es la clase Creator, debido a que, es la responsable de crear los objetos de tipo. Decidimos utilizar este patrón debido a que, es abierto a la extensión pero cerrado a la modificación. Lo cual es muy importante, ya que, en caso de querer crear más objetos podemos hacerlo sin necesidad de modificar lo ya creado(Reutilización del código).
Tomamos la decisión de tener varios CreatorUnity y CreatorC#, uno por cada objeto a crear....

1. Herencia (ITEMS) LISTO
 Utilizamos herencia en este caso debido a que, esta clase será la base de mucho de lo que creamos en el proyecto. La clase descendiente(Width, Image, Height, etc.) va a heredar automáticamente los atributos,propiedades de Items. Las clases hijas aumentan la especialización dependiendo de lo que deben hacer cada una de ellas en el juego.

3. Observer 
El patrón Observer es un pilar fundamental en nuestro juego, debido a que, es el MOTOR del mismo. Este será el encargado en tomar las decisiónes, es la lógica del juego. Para esto, definimos una dependencia de tipo entre objetos, de manera que cuando uno de los objetos cambie,notifica a todos los dependientes. (PONER CUAL ES) MOTOR- Observa cada evento de la app. Le avisa todo al motor Información tomada de: "Design Patterns: Elements of Reusable Object-Oriented Software"

4. Factory Abstract - LISTO
 Este patrón creado por "The Gang of Four" es fundamental para la creación de los objetos del juego, debido a que, nos soluciona el problema de como diferentes familias de objetos puedan ser creadas. La principal clave para utilizar el patrón es asbtraer el proceso de la creación, por esto, tenemos la clase .... Lo que nos permite este patrón es, delegar la creación de instancia de un objeto, lo cuál es fundamental porque cuanto más divida este la funcionalidad del código mejor, cada clase se encarga de una creación especifica.

Información tomada de: "Design Patterns: Elements of Reusable Object-Oriented Software"

5. Singleton - LISTO
 El patrón Singleton nos permite garantizar la existencia de una sola instancia de clase. Además el acceso a esa única instancia tiene que ser global. Esto es de mucha utilidad debido a que, tomamos la decisión de que en nuestro juego haya un único World, por tanto, Singleton es fundamental debido a que se ejecuta una única vez, así nos aseguramos que sólo existe una instancia. En caso de querer llamarlo en cualquier parte del programa se puede hacer.

6. Interfaz IButton - YA PASADA
 Esta interfaz es creada, debido a que, cuando en un futuro querramos tener difrentes tipos de botones lo podamos hacer. Por ejemplo, un botón que sea una imagen,un botón contador, botón audio, etc. En este caso, estamos pensando en la funcionalidad futura del código, para cuando debamos ampliar el juego.