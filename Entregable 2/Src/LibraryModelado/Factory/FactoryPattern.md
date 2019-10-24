Para la creación de todos los objetos de nuestro juego utilizamos el patrón de diseño
"Factory Abstract".
°Este patrón creado por "The Gang of Four" es fundamental para la creación de los objetos del juego, debido a que, nos soluciona el problema de como diferentes familias de objetos puedan ser creadas. La principal clave para utilizar el patrón es asbtraer el proceso de la creación. Lo que nos permite este patrón es, delegar la creación de instancia de un objeto, lo cuál es crucial porque cuanto más divida este la funcionalidad del código mejor, cada clase se encarga de una creación especifica, lo cual ayuda a la reutilización del código. 
°En nuestro código, tenemos tantos Factory como elementos que queremos crear, Factory Button, Factory Money, FactoryImage, cuando querramos agregar más componentes crearemos más Factory siguiendo el mismo patró. 


Información tomada de: "Design Patterns: Elements of Reusable Object-Oriented Software"