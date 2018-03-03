using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VirtualCar;

namespace VirtualCar.Controllers.FrontEndVirtualCar
{
    [Authorize]
    public class PedidosController : Controller
    {
        private VirtualCarDBEntities db = new VirtualCarDBEntities();

        // GET: Pedidos
         [Authorize(Users = "isragoo.prez@gmail.com")]
        public ActionResult Index()
        {
            var pedidoes = db.Pedidoes.Include(p => p.Cliente);
            return View(pedidoes.ToList());
        }

        // GET: Pedidos/Details/5
         [Authorize(Users = "isragoo.prez@gmail.com")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }
        [Authorize(Users = "isragoo.prez@gmail.com")]
        // GET: Pedidos/Create
        public ActionResult Create()
        {
            ViewBag.id_cli = new SelectList(db.Clientes, "Id", "Nombres");
            return View();
        }

        // POST: Pedidos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "isragoo.prez@gmail.com")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,id_cli,Fecha_ped,Subtotal,Total,IGV")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedidoes.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cli = new SelectList(db.Clientes, "Id", "Nombres", pedido.id_cli);
            return View(pedido);
        }
         [Authorize(Users = "isragoo.prez@gmail.com")]
        // GET: Pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cli = new SelectList(db.Clientes, "Id", "Nombres", pedido.id_cli);
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Users = "isragoo.prez@gmail.com")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,id_cli,Fecha_ped,Subtotal,Total,IGV")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cli = new SelectList(db.Clientes, "Id", "Nombres", pedido.id_cli);
            return View(pedido);
        }
        [Authorize(Users = "isragoo.prez@gmail.com")]
        // GET: Pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "isragoo.prez@gmail.com")]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedidoes.Find(id);
            db.Pedidoes.Remove(pedido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
