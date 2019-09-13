# pii_2019_2_equipo4

Entregable 1: HTML

Este codigo permite extraer informacion sobre los tag, de un archivo HTML ingresado. Existen dos versiones del codigo, con distintas formas de trabajar, pero mantienendo el mismo objetivo.
Se diferencian en que la primera version original del codigo, lee un archivo HTML en donde se encuentren solamente un Tag por linea.

En la segunda version, la modificacion que realizamos, es que filtre el Archivo HTML de otra
manera. En donde no sea necesario que exista solamente un Tag por linea, sino que logra leerlo y 
filtrarlo aunque se encuentre todo el contenido en una sola linea.

- Version 1: Lee el archivo HTML cuando este se encuentra de la siguiente forma:

<html>
	<body>
		<font color="blue" size="3">
			Ingrese su nombre 
		</font>
		<input type="text" name="nombre" maxlength="8"/>
		<br/>
		<font size="2">
			Máximo 8caracteres
		</font>
	</body>
</html>


- Version 2: Puede leer el archivo HTML cuando este se encuentra de la siguiente forma, o la anterior:

<html><body><font color="blue" size="3">Ingrese su nombre </font><input type="text" name="nombre" maxlength="8"/><br/><font size="2">Máximo 8caracteres</font></body></html>