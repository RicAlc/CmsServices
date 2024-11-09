# Proyecto Web API - .NET 8 con SQL Server

**Descripción del Proyecto**  
API web de un CMS con .NET 8, permite la creación, edición, visualización y eliminación de clientes y facturas.

## Requisitos

- **.NET 8 SDK** (Versión 8 o superior)
- **SQL Server**
- **Visual Studio** (Recomendado para seguir las instrucciones)

## Instalación

### 1. Clonar el repositorio
```
git clone git@github.com:RicAlc/CmsServices.git
```

### 2. Abrir el proyecto

Abre visual studio y selecciona "Abrir un proyecto o solución", navega hasta donde se encuentre la carpeta principal de la app y selecciona el archivo "CmsServices.sln".

### 3. Restaurar dependencias

En el explorador de soluciones haz click derecho en el proyecto principal (el primero de arriba en el arbol del proyecto) y haz click en Restaurar paquetes NuGet

### 4. Configuración de la base de datos

Este proyecto utiliza **SQL Server** para almacenar los datos. La base de datos utilizada en el proyecto se llama **Ventas**, importala manualmente con el script SQL o Si aún no tienes la base de datos creada, puedes ejecutarla las **migraciones de Entity Framework Core**.
Ejecuta en la terminal del Package manager el siguiente comando:

```bash
Update-database
```

#### 4.1 Configurar la cadena de conexión

Abre el archivo `appsettings.json` y actualiza la cadena de conexión a tu servidor de SQL Server si está diferente:

```
"ConnectionStrings": {
  "Connection": "Server=.\\SQLExpress;Database=Ventas;Trusted_Connection=true;TrustServerCertificate=true"
}
```

### 4. Ejecutar la API

Para ejecutar la aplicación dando click en el boton de ejecutar (triangula verde lleno) asegurandote que lo haga con la opción II Express

### 5. Pruebas de la API

Una vez que la API esté en ejecución, se abrirá una pestaña del navegador con la documentación de la API hecha en swagger o bien puedes usar la aplicación hecha con angular en: https://github.com/RicAlc/cms-app

## Dependencias

- **.NET 8 SDK
- **Entity Framework Core**
- **Entity Framework Core Tools**
