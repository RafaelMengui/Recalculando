# Bienvenido/a a RECALCULANDO❗️❗️ 
_Recalculando es un juego creado para niños que padecen discalculía, esta aplicación esta pensada para  ayudarlos a mejorar de forma entretenida_

 ## Punto de partida ⏩

Se nos ha presentado el caso de Alfonsina, una niña de 8 años de edad que está cursando tercero de primaria en un colegio privado la cual padece de discalculia. El objetivo de esta aplicación es que funcione como herramienta de trabajo para practicar diversas habilidades matemáticas tanto en un contexto educativo como en su tiempo libre. De acuerdo a las dificultades de Alfonsina, se ha decidido trabajar en las siguientes áreas: el sentido de las operaciones, la mecánica de sustracción y suma, el orden serial y la recitación de la serie numérica, el conteo con correspondencia, el cambio de decena y la caligrafía de los números.

## Decisión en el modelado 🔧
_Para realizar este juego tomamos diferentes decisiones las cuales nos parecieron prudentes para el correcto desarrollo de la misma._ 

Cuando comenzamos a realizar la aplicación nos surgieron algunos problema, primero que nada no sabiamos como crear todos los objetos que debiamos tener en la misma, era muy poco eficiente crearlos de a uno sin utilizar ningún patrón de diseño. Por esto, decidimos buscar en el libro recomendado "Design Patterns", el cual nos plantea diferentes soluciones para varios problemas. En nuestro caso, el patrón que solucionaba esto era _FactoryAbstract_, debido a que, el mismo nos permite delegar la creación de instancia de un objeto, esto es crucial porque cuanto más divida este la funcionalidad del código mejor, cada clase se encarga de una creación especifica, lo cual ayuda a la reutilización del código. Por estas razones, este patrón fue el utilizado en nuestro código, el cual nos fue muy útil.


Luego de resolver el problema de la creación de objetos, debiamos pensar como crear la lógia de nuestro juego. Para solucionar esto pensamos en la creación de varios motores. Por un lado, tenemos en motor principal, la función del mismo será controlar que todos los motores subprincipales, es decir, los de cada juego, estén funcionando de manera correcta. Esta modalidad que decidimos adoptar utiliza el patrón de diseño _Expert_, este nos dice que, debemos asignar la responsabiliad al experto en la información, es decir, la clase que tiene la información necesaria. Por esto, cada uno de nuestros motores cumple con el patrón, ya que, cada motor tiene la información precisa para la lógica de su correspondiente juego. 


## Diseño de la aplicación 🔛

La aplicación consta de cuatro diferentes personajes, cada uno ayuda al niño a mejorar en distintos apectos de la discalculía. 

### ✔️ Científico :
_Este juego consta de tres pequeños dentro, todos ayudan al niño con la sustracción y suma_

* El niño debe realizar las sumas pedidas, arrastrando los billetes dependiendo de la opción que crea correcta
* Por pantalla se muestra una consigna, la cual, pide realizar una cuenta dada. Hay dos botones con diferentes opciones, el niño debe elegir cual es la respuesta correcta, de acuerdo a la suma que se dio. 
* En este nivel se plantea una pregunta respecto a un problema matemático, el niño debe elegir que operación es la indicada para el problema, ya sea, sustracción o adición.
* Aparecen sumas por pantalla realizadas de manera que el niño pueda visualizarlas, con un resultado, la idea del juego es que se elija si la suma fue realiza de forma correcta o no. 

### ✔️Sabelotodo: 
_Este personaje cuenta con información para que el niño repase los aspectos sobre la matemática que son importantes._

Contiene:
* Tablas de multiplicar
* Recta numérica con números hasta el 500
* Números y la cantidad que representan

### ✔️ Cocinero:
En este caso, el personaje le pedirá al niño que arrastre una cantidad determinada de ingredientes para hacer una receta. Se debe arrastrar los alimentos hacía el bowl, si el alimento que se coloco es el correcto se seguirá jugando, en caso contrario, se puede seguir intentando. 

### ✔️ Mago:
En este juego lo central es que el niño pueda prácticar la secuencia numérica, es decir, el orden de los números. Tendrá cinco pantallas con diferentes ejercicios para realizar. 
En cada una de las pantallas, hay varios árboles con números los cuales representan secuencias de números, hay un número que falta en la misma, lo que debe hacer el niño es escribir por pantalla cual es el número que no esta presente. 


## Comencemos a jugar 🚀 
_Estas instrucciones te permitirán tener el juego en tu celular, ya sea Android o iOS._

### Pre-requisitos 📋
_Que cosas necesitas para instalar el juego_

Para comenzar a jugar lo único que se debe hacer es autorizar tu celular para descargar aplicaciones que no necesariamente sean descargadas desde la plataforma de tu celular. ¡Tranquilo nuestro juego es seguro!

### ¡A jugar! 😊

Una vez que ya esta la aplicación en tu celular, lo único que resta es abrirla. Dentro de la misma se verán los distintos personajes, al elegir uno se abrirá su juego correspondiente. 

**¡Ya estás listo para jugar! Esperamos que disfrutes de RECALCULANDO.**





## Autores ✒️
**Agustina Marrero, Nicolas Puig, Rafael Mengui, Santiago Omodey**
