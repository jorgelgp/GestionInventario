# Gestion Inventario
<h3>Ejercicio Gestion de Inventarios</h3>

La aplicación consta de una interfaz web MVC, un API REST y un proyecto de pruebas unitarias.

Para ejecutar la aplicación en visual studio 2019 pulsamos f5 y se nos abre el navegador, la aplicación se ejecuta sobre el IISExpress.
Desde esta interfaz web podemos probar la aplicación. Además con cualquier cliente RES (Postman) podemos probar el WEB API.

La aplicación tiene la siguiente estructura:

<b>Web API:</b>
- Los capa de servicios distribuidos con los controladores. (No deberían estar en el mismo proyecto que los controladores de la interfaz web)
- La capa de aplicación debería estar en un proyecto aparte, he puesto solo una carpeta con los DTOs.
- Los servicios de aplicación se omiten por falta de tiempo.
- La capa del Dominio con las entidades y las interfaces del repositorio (deberían estar en un proyecto aparte, se ha hecho un atajo)
- La capa de infraestructura con el repositorio (debería estar en un proyecto aparte, se ha hecho un atajo)
- La capa de infraestructura transversal con los log de errores no se ha implementado por falta de tiempo.
- Falta por implementar la seguridad en el WEB API, utilizando JSON Web Tokens, debido a la falta de tiempo.

<b>Interfaz web MVC:</b>
- Vistas y carpeta de javascripts (la vista Index tiene su codigo javascript en el fichero inventario.js)
- Controladores
- Hubs para SignalR. (Se utiliza para notificar los elementos caducados)
- En lugar de que los controladores llamen a los servicios de aplicacion (no se han desarrollado por falta de tiempo) se llama directamente a las entidades del dominio.

He utilzado en Boostrap en lugar de materializeCss, porque no se me inicializaba el ComboBox "select" con los tipos de elementos.
