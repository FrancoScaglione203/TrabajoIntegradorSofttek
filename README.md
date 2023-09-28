# TrabajoIntegradorSofttek
Proyecto desarrolado en .NET CORE 6 a partir de unas consignas que se nos brindaron en el curso intensivo de 6 semanas "Academia .Net" dictado por la Universidad del Museo Social Argentino en conjunto con el empresa Softtek
https://drive.google.com/file/d/1yIRq0M9FdApUU2c8_OUoryahJM9B9cO8/view

---
---
## **Especificación de la Arquitectura**
### **Capa Controller**
Será el punto de entrada a la API. En los controladores deberíamos definir la menor cantidad de lógica posible y utilizarlos como un pasamanos con la capa de servicios.
​
### **Capa DataAccess**
Es donde definiremos el DbContext. Ademas, tiene dos subcapas
*	DataBaseSeeding: donde se encuentran las seeds de cada entidad para realizar Migration con EntityFrameWork
*	Repositories: donde definiremos las clases e interfaces correspondientes para realizar el repositorio genérico y los repositorios individuales, donde estara la mayor parte de la logica.

### **Capa DTOS**
En esta capa estan definidos todos los DataTransferObjects.

### **Capa Entities**
En esta capa estan definidas todas las entidades 
​
### **Capa Helpers**
Definiremos lógica que pueda ser de utilidad para todo el proyecto. En este caso el paginado, el encriptamiento de clave y el generador de JWT

### **Capa Infrastucture**
En esta capa se encuentran clases para el manejo de la comunicacion por medio de protocolos http

### **Capa Logs**
Capa que genera el Serilog donde se encuentran los txt donde registra los datos

### **Capa Migrations**
Capa que se genera al realizar el migration con EntityFrameWork donde registra el migration y los datos insertados en la base de datos

### **Capa Services**
Capa donde se desarrollan la clase e interfaz UnitOfWorkService que trabaja en conjunto con el patron Repository

---
---
## **Entidades**
Tenemos las 4 principales de la consigna que son Servicio, Proyecto, Trabajo y Usuario. Además también se agregaron 2 entidades Login(Para el manejo de login de usuario) y Role(Para el manejo de políticas de autorización)

---
---
## **Controllers**
Hay un controller por entidad: Servicio, Proyecto, Trabajo, Usuario, Login y Role

---
---
## **EndPoints Generales**
Las 4 entidades principales comparten EndPoints con retornos similares donde:
-	Se retorna lista de todos los elementos de la entidad
-	Se ingresa un id y retorna el elemento con ese id
-	Se envia id por route y entidad por body con datos nuevos para luego remplazar al que tiene ese id
-	Se envia id por route y realiza una baja lógica actualizando la propiedad Activo a false
-	Se envia id por route y realiza un alta lógica actualizando la propiedad Activo a true
-	Se envia id por route y realiza una baja física


## **EndPoints Específicos**
- Login: Se envia por parametro Cuil y Clave y si son correctos retorna un token con el cual se loguea y se utiliza para manejar autorizaciones de usuarios
-	ServiciosActivos: Devuelve lista de Servicios donde la propiedad Estado es igual a true
-	ProyectosByEstado: Se ingresa un numero de estado y devuelve los Proyectos que se encuentran en ese estado
-	C.R.U.D Roles: Solo tiene cuatro endpoints donde: devuelve todos los roles, alta, modificación y baja
---
---

## **Paquetes Instalados**
![Logo de Mi Proyecto](https://i.imgur.com/gGi19lj.jpg)

---
---

## **Especificación de GIT**​
* Se implento el patron GitFlow. La rama donde se encuentran las versiones finales es Master, la rama principal a partir de la cual se crean ramas es Develop. La nomenclatura para el nombre de las ramas será la sigueinte: Feature/xx-Titulo (donde xx corresponde con el número de historia)
* El título del pull request debe contener el título de la historia tomada.
---
---
## **Autor**​
* Scaglione Franco
---
---
## **Contacto**
franco.scaglione2@gmail.com
