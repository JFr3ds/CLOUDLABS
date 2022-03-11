# CLOUDLABS
Cloud labs programing test 
Un colegio requiere el desarrollo de un programa que permita a sus profesores acceder de manera
rápida y sencilla a la información de las notas de sus estudiantes.
Se requiere que el programa le muestre al profesor una tabla con la información de sus
estudiantes, la cual contiene:

Nombre del estudiante, Apellido del estudiante, código de identificación del estudiante (ej: 0000),
correo institucional del estudiante y nota final en la materia.
Dicha información debe ser leída por el programa desde un archivo JSON, y una vez vista en
pantalla, el profesor debe poder ver toda la tabla de estudiantes y para cada estudiante poder
marcar una casilla de aprobado o reprobado.
Adicionalmente, el programa debe contar con un botón de verificación, el cual al ser presionado
compara la nota final de cada estudiante con la casilla marcada por el profesor y lanza una alerta
que confirme si el profesor ha marcado todas las casillas correctamente o si ha cometido algún
error. (Notas en escalas de 0 a 5, con calificación mínima de aprobación de 3)
Luego de esto, en cuanto el profesor haya marcado todas las casillas correctamente, el programa
debe pasar a otra pantalla en donde el profesor tenga una visualización de sus estudiantes con sus
nombres y deba hacer drag and drop para clasificarlos entre aprobados y reprobados.

Una vez clasificados los estudiantes entre aprobados y reprobados, el programa debe lanzar una
alerta que verifique si han sido ubicados de manera correcta o si el profesor debe revisar este
proceso y repetirlo.
La interacción finaliza con una alerta de felicitación en cuanto el profesor ubica correctamente a
todos sus estudiantes. (El programa no debe cerrarse en éste momento)
Los requerimientos funcionales de la aplicación son los siguientes:

● Lista de estudiantes:

● La aplicación debe obtener la lista de estudiantes desde un archivo JSON que
incluya todos los datos solicitados.

● El programa debe estar generando la tabla de forma dinámica a partir de este
archivo. Es decir, si se borra la información de un estudiante del archivo JSON, el
programa debe seguir funcionando y dibujar la tabla sin la información borrada.
No debe crashear si esto ocurre.


● Check aprobado/reprobado:

● El profesor debe poder marcar en una casilla de cada estudiante de la lista si ha
aprobado o reprobado su materia.

● El botón validar debe comparar el valor que aparece en la tabla con la escala de
aprobación y mandar la alerta acorde a esta información. (Ésto se revisará tanto
en la ejecución del programa como revisando el código escrito)

● Pantalla drag & drop

● Esta pantalla debe mostrar una visualización de todos los estudiantes de la tabla
en una zona “neutra” y permitir al profesor arrastrarlos utilizando un drag and
drop hacia las zonas de aprobado y reprobado.

● El simulador debe nuevamente comparar correctamente la ubicación de cada
estudiante con la nota que se mostraba en la tabla y si éste había aprobado o
reprobado la materia. (Ésto se revisará tanto en la ejecución del programa como
revisando el código escrito)

● Funcionalidades extra:
●
No es necesario, pero es un plus si al programa se le añaden funciones extra, como
por ejemplo poder editar el JSON y recargarlo durante la ejecución del programa
(sin necesidad de cerrarlo y ejecutarlo de cero) o el poder ver la tabla de
calificaciones en la pantalla del drag & drop. Funciones y adiciones creativas y
útiles al programa son un gran plus.
