ClaroVideoUWP
==================================================
Ejercicio para america movil contenidos en UWP

Proyectos incluidos en la solución y sus tecnologías
--------------------------------------
**ClaroVideoApp:** Aplicación WUP.
- HTML5/JS
- jQuery 2.2.4
- Bootstrap 3.3.7
- FontAwesome 4.7.0
- Angular 1.6.5

**ClaroVideoWepAPIs:** Adquisición y procesamiento de información para la creación de los servicios HTTP.
- C# .NET 4.6.1
- EntityFramework 6.2.0
- ASP.NET MVC 5.2.4
- MSSQL Local DB 2016

**ClaroVideoWebAPIs.Test:** Pruebas Unitarias para el proyecto `ClaroVideoWepAPIs`
- TestFramework 1.2.0 

Compilación del proyecto
--------------------------------------
El proyecto fue programado y compilado **Visual Studios Community 2017**

1. Una vez obtenido en código del proyecto abrir el archivo de la solución `ClaroVideo.sln`.
2. Una vez abierto el proyecto dar clic derecho sobre la solución en el explorador de soluciones y realizar las siguientes acciones:
	- Restaurar paquetes de NuGet.
	- Re-compilar todos los archivo de la solución (LESS, Minify).
	- Finalmente, compilar solución.
3. **[Ejecutar pruebas unitarias](https://msdn.microsoft.com/es-es/library/hh270865.aspx)** (Opcional): En la opción Pruebas de la barra de menús de VS17, dar clic en `Ejecutar > todas las pruebas`.

Ejecución del proyecto
--------------------------------------
1. Verificar que el proyecto **ClaroVideoApp(Univelsal Windows)** sea el [proyecto de inicio](https://msdn.microsoft.com/es-es/library/a1awth7y(v=vs.120).aspx).
2. [Ejecuta la aplicación](https://msdn.microsoft.com/es-mx/library/dn757049.aspx) como `Local` en las opciones de plataforma.

Agregar nuevos elementos en la base de datos
--------------------------------------

1. Abrir la clase `ClaroVideoUWP\ClaroVideoWebAPIs\Migrations\Configuration.cs`.
2. Agregar nuevos elementos a los arrays establecidos
```
context.Categories.AddOrUpdate(x => x.Id,
	new Category() { ... }
);

context.RatingCodes.AddOrUpdate(x => x.Id,
	new RatingCode() { ... }
);

context.VCards.AddOrUpdate(x => x.Id,
	new VCard() { ... }
);
```
3. Ejecutar en la consola de administracion de paquetes: 
```
PM> Update-Database
```

Consideraciones
--------------------------------------
1. Se uso MSSQL Local DB en lugar de SQLite por que un no existe soporte total con EF en VS2017 [View Ticket](https://system.data.sqlite.org/index.html/tktview?name=8292431f51) (Cuando exista soporte oficial, es muy sencillo cambiar el proyecto a SQLite: cambiar el adaptador db y ejecutar el scaffold de EF).
2. La aplicación UWP se hizo con WEB APIs EF Code Firts y UWP JS por lo que entendí de los requerimientos y la falta de respuesta a mis email sobre mis dudas.
3. Se implemento un inyector de dependencias ´ClaroVideoWebAPIs\Models\InjectorImages.cs´
4. Se utilizaron los patrones de diseño: Data Transfer Objects y Object Literals

Screenshots
--------------------------------------
<div>
<img src="https://raw.githubusercontent.com/hmartinezr/ClaroVideoUWP/master/screenshots/ss2.PNG" width="200">
<img src="https://raw.githubusercontent.com/hmartinezr/ClaroVideoUWP/master/screenshots/ss3.PNG" width="200">
<img src="https://raw.githubusercontent.com/hmartinezr/ClaroVideoUWP/master/screenshots/ss4.PNG" width="200">
<img src="https://raw.githubusercontent.com/hmartinezr/ClaroVideoUWP/master/screenshots/ss5.PNG" width="340">
<img src="https://raw.githubusercontent.com/hmartinezr/ClaroVideoUWP/master/screenshots/ss6.PNG" width="340">
</div>
