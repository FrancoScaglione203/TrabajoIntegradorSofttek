# TrabajoIntegradorSofttek
Proyecto desarrolado en .NET CORE 6 a partir de unas consignas que se nos brindaron en el curso intensivo de 6 semanas "Academia .Net" en conjunto con el empresa Softtek
https://drive.google.com/file/d/1yIRq0M9FdApUU2c8_OUoryahJM9B9cO8/view

## **Especificación de la Arquitectura**
### **Capa Controller**
Será el punto de entrada a la API. En los controladores deberíamos definir la menor cantidad de lógica posible y utilizarlos como un pasamanos con la capa de servicios.
​
### **Capa DataAccess**
Es donde definiremos el DbContext. Ademas, tiene dos subcapas
*	DataBaseSeeding: donde se encuentran las seeds de cada entidad para realizar Migration con EntityFrameWork
*	Repositories: donde definiremos las clases e interfaces correspondientes para realizar el repositorio genérico y la unidad de trabajo

### **Capa DTOS**
En esta capa estan definidos todos los DataTransferObjects.

### **Capa Entities**
En esta capa estan definidas todas las entidades 
​
### **Capa Helpers**
Definiremos lógica que pueda ser de utilidad para todo el proyecto. En este caso el paginado, el encriptamiento de clave y el generador de JWT

### **Capa Infrastucture**
En esta capa se encuentran clases para el manejo de la comunicacion por medio de protocolos http

### **Capa Services**
Capa donde se encuentra clase e interfaz UnitOfWorkService

​
## **Especificación de GIT**​
* Se crean ramas a partir de la rama Develop. La nomenclatura para el nombre de las ramas será la sigueinte: Feature/xx-Titulo (donde xx corresponde con el número de historia)
* El título del pull request debe contener el título de la historia tomada.

## **Autor**
Scaglione Franco
