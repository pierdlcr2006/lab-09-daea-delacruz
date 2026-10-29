using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LaboratorioCRUDProductos.Models;

namespace LaboratorioCRUDProductos.Controllers
{
    public class ProductoController : Controller
    {
        private void InicializarProductos()
        {
            if (Session["productos"] == null)
            {
                List<ProductoModel> productos = new List<ProductoModel>();

                productos.Add(new ProductoModel
                {
                    Id = 1,
                    Nombre = "Mouse Logitech",
                    Descripcion = "Mouse USB",
                    Precio = 45,
                    Stock = 20
                });

                productos.Add(new ProductoModel
                {
                    Id = 2,
                    Nombre = "Teclado Redragon",
                    Descripcion = "Teclado mecanico",
                    Precio = 150,
                    Stock = 10
                });

                productos.Add(new ProductoModel
                {
                    Id = 3,
                    Nombre = "Monitor Samsung",
                    Descripcion = "Monitor de 24 pulgadas",
                    Precio = 650,
                    Stock = 5
                });

                Session["productos"] = productos;
            }
        }

        public ActionResult Index()
        {
            InicializarProductos();
            return View(Session["productos"]);
        }

        public ActionResult Details(int id)
        {
            InicializarProductos();
            List<ProductoModel> productos = (List<ProductoModel>)Session["productos"];
            ProductoModel producto = productos.Where(x => x.Id == id).FirstOrDefault();

            if (producto == null)
            {
                return HttpNotFound();
            }

            return View(producto);
        }

        public ActionResult Create()
        {
            InicializarProductos();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoModel model)
        {
            InicializarProductos();
            List<ProductoModel> productos = (List<ProductoModel>)Session["productos"];
            ProductoModel producto = productos.Where(x => x.Id == model.Id).FirstOrDefault();

            if (producto != null)
            {
                ModelState.AddModelError("Id", "Ya existe un producto con ese Id.");
            }

            if (ModelState.IsValid)
            {
                productos.Add(model);
                Session["productos"] = productos;
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            InicializarProductos();
            List<ProductoModel> productos = (List<ProductoModel>)Session["productos"];
            ProductoModel producto = productos.Where(x => x.Id == id).FirstOrDefault();

            if (producto == null)
            {
                return HttpNotFound();
            }

            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoModel model)
        {
            InicializarProductos();
            List<ProductoModel> productos = (List<ProductoModel>)Session["productos"];
            ProductoModel producto = productos.Where(x => x.Id == model.Id).FirstOrDefault();

            if (producto == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                producto.Nombre = model.Nombre;
                producto.Descripcion = model.Descripcion;
                producto.Precio = model.Precio;
                producto.Stock = model.Stock;
                Session["productos"] = productos;
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            InicializarProductos();
            List<ProductoModel> productos = (List<ProductoModel>)Session["productos"];
            ProductoModel producto = productos.Where(x => x.Id == id).FirstOrDefault();

            if (producto == null)
            {
                return HttpNotFound();
            }

            return View(producto);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InicializarProductos();
            List<ProductoModel> productos = (List<ProductoModel>)Session["productos"];
            ProductoModel producto = productos.Where(x => x.Id == id).FirstOrDefault();

            if (producto == null)
            {
                return HttpNotFound();
            }

            productos.Remove(producto);
            Session["productos"] = productos;
            return RedirectToAction("Index");
        }
    }
}
