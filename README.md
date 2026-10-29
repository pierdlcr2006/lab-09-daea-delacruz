# Lab 09 DAEA · Inventario DelaCruz

Aplicación web ASP.NET MVC 5 para registrar y administrar productos. La lógica original se conserva en `Controllers`, `Models` y `Views`; los productos se mantienen en sesión para el flujo CRUD del laboratorio.

## Estructura MVC

- `Models/ProductoModel.cs`: modelo y validaciones.
- `Controllers/ProductoController.cs`: acciones del CRUD.
- `Views/Producto/`: listado, registro, edición, detalle y eliminación.
- `Content/Site.css`: estilos visuales de la aplicación.

## Ejecución

Abrir `LaboratorioCRUDProductos.slnx` en Visual Studio sobre Windows con ASP.NET/.NET Framework 4.8 y restaurar los paquetes NuGet. El proyecto usa IIS Express.

Desarrollado por **Piero de la Cruz**.
