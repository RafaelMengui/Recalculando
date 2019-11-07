# Patrones utilizados en todos los Factory # 


- Para la creación de todos los objetos de nuestro juego utilizamos el patrón de diseño "Factory Abstract".
°Este patrón creado por "The Gang of Four" es fundamental para la creación de los objetos del juego, debido a que, nos soluciona el problema de como diferentes familias de objetos puedan ser creadas. La principal clave para utilizar el patrón es asbtraer el proceso de la creación. Lo que nos permite este patrón es, delegar la creación de instancia de un objeto, lo cuál es crucial porque cuanto más divida este la funcionalidad del código mejor, cada clase se encarga de una creación especifica, lo cual ayuda a la reutilización del código. 
°En nuestro código, tenemos tantos Factory como elementos que queremos crear, Factory Button, Factory Money, FactoryImage, cuando querramos agregar más componentes crearemos más Factory siguiendo el mismo patrón. 

Información tomada de: "Design Patterns: Elements of Reusable Object-Oriented Software"

- Todos nuestros Factory cumplen con el principio de SRP
El principio de SRP, el enunciado establece que cada clase debe tener responsabilidad sobre una parte de la funcionalidad proporcionada por el programa, y que la responsabilidad debe estar completamente encapsulada por la clase. Esto se cumple claramente en cada uno de los Factory, debido a que, cada uno tiene una única responsabilidad, la de crear el objeto que se le pide. Los Factory tienen toda la información necesaria para la creación del objeto. 

- Todos nuestros Factory cumplen con el Patrón Low Coupling
La principal idea de este patrón es que el acomplamiento se mantenga siempre bajo, esto se logra cuando las clases están lo menos ligadas posibles entre sí. Esto es muy bueno debido a que si quiero hacer un cambio en alguna, no debe realizarse un cambio total del código sino que, simplemente modificar la parte que nos interesa, de esta forma potenciamos la reutilización. Esto se ve claramente en todas nuestras creaciones del juego, cada Factory crea un objeto, en caso de querer cambiarlo debemos cambiar el Factory que le pertence y no el código completo.