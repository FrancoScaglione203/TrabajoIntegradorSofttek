# TrabajoIntegradorSofttek
Proyecto desarrolado en .NET CORE 6 a partir de unas consignas que se nos brindaron en el curso intensivo de 6 semanas "Academia .Net" en conjunto con el empresa Softtek
https://drive.google.com/file/d/1yIRq0M9FdApUU2c8_OUoryahJM9B9cO8/view

## **Especificación de la Arquitectura**
### **Capa Controller**
Será el punto de entrada a la API. En los controladores deberíamos definir la menor cantidad de lógica posible y utilizarlos como un pasamanos con la capa de servicios.
​
### **Capa DataAccess**
Es donde definiremos el DbContext,crearemos los seeds y tambien donde se encuentra la capa repositories

### **Capa Repositories**
En esta capa definiremos las clases correspondientes para realizar el repositorio genérico y la unidad de trabajo

### **Capa Entities**
En este nivel de la arquitectura definiremos todas las entidades de la base de datos.
​
### **Capa Helpers**
Definiremos lógica que pueda ser de utilidad para todo el proyecto. En este caso el paginado, el encriptamiento de clave y el generador de JWT

### **Capa Infrastucture**
En esta capa se encuentran clases para el manejo de la comunicacion por medio de protocolos http

​
## **Especificación de GIT**​
* Se deberán crear las ramas a partir de DEV. La nomenclatura para el nombre de las ramas será la sigueinte: Feature/Us-xx (donde xx corresponde con el número de historia)
* El título del pull request debe contener el título de la historia tomada.

## **Autor**
Scaglione Franco
