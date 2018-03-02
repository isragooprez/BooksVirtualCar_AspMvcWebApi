using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VirtualCar.Models;
using Microsoft.AspNet.Identity;

namespace VirtualCar.Controllers.FrontEndVirtualCar
{
    public class VirtualCarController : Controller
    {

        private VirtualCarDBEntities db = new VirtualCarDBEntities();

        //  [HttpPost]
        //public ActionResult AddCar(VirtualCarModels _virtualCar)
        //{
        //    return View(_virtualCar);
        //    //return RedirectToAction("AddCar", "VirtualCar", _virtualCar);
        //}
        DateTime dateTimeNow = DateTime.Now;
        private static string currentUser = WindowsIdentity.GetCurrent().User.Value.ToString();
        string id_us = currentUser;
        private int counterProd = 0;


        Pedido pedido = new Pedido()
        {
            id_cli = currentUser,
            Fecha_ped = System.DateTime.Now,
            IGV = 12,
            Subtotal = 0,
            Total = 0
        };

        DetallePedido productoPedido = new DetallePedido();


        dynamic carVirtul = new System.Dynamic.ExpandoObject();
        public ActionResult AddCar(int? id, VirtualCarModels _virtualCar)
        {
            double _igv_generado = 0;
            ViewBag.Message = "No existen libro agregados.";

            if (id > 0)
            {
                var productoFind = db.Productoes.Find(id);
                if (_virtualCar.Count > 0)
                {
                    var isExisteProdVirtualCar = (from p in _virtualCar where p.Id == id select p).Any();
                    if (isExisteProdVirtualCar == true)
                    {
                        var prodVirtualCar = (from p in _virtualCar where p.Id == id select p).First();

                        foreach (Producto item in _virtualCar)
                        {
                            if (prodVirtualCar.Id == item.Id)
                                item.Stock++;
                        }
                    }
                    else
                    {
                        productoFind.Stock = 1;
                        _virtualCar.Add(productoFind);
                        counterProd++;
                    }
                }
                else
                {
                    productoFind.Stock = 1;
                    _virtualCar.Add(productoFind);
                }
            }
            if (_virtualCar.Count >= 1 && _virtualCar != null)
            {
                foreach (var item in _virtualCar)
                {
                    //falta el producnto tenga el campo iva
                    if (item != null)
                    {
                        pedido.Subtotal += item.Precio;
                        _igv_generado = (double)(pedido.Subtotal * pedido.IGV) / 100;
                        pedido.Total += pedido.Subtotal + ((pedido.Subtotal * pedido.IGV) / 100);
                    }


                    //db.DetallePedidoes.Add(productoPedido);

                }
                ViewBag.Subtotal = pedido.Subtotal.ToString();
                ViewBag.Total = pedido.Total.ToString();
                ViewBag.IGV = _igv_generado;
                //db.Pedidoes.Add(pedido);
                //db.SaveChanges();
                if (id == null)
                {
                    return View(_virtualCar);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.counterProd = counterProd.ToString();

            return View(_virtualCar);
        }

        public ActionResult DetalleCar(VirtualCarModels _virtualCar)
        {
            ViewBag.Message = "No existen libro agregados.";
            return RedirectToAction("AddCar", _virtualCar);

        }
        Cliente cli = new Cliente();

        public ActionResult GenerarPedido(VirtualCarModels _virtualCar)
        {
            cli.Id = User.Identity.GetUserId();
            Cliente resexistCli = db.Clientes.Where(c=>c.Id==cli.Id).First();

            pedido.Cliente = resexistCli;
            pedido.id_cli = User.Identity.GetUserId();
            pedido.Fecha_ped = dateTimeNow;
           
           

            
            foreach (Producto item in _virtualCar)
            {
                DetallePedido factura = new DetallePedido();
                factura.id_ped = pedido.Id;
                factura.id_pro = item.Id;
                factura.Cantidad = item.Stock;
                factura.Precio_venta = item.Precio * factura.Cantidad;
                factura.Descuento = ((item.Precio * 5) / 100);
                factura.Importe = item.Stock * item.Precio;

                pedido.Subtotal += item.Precio-factura.Descuento;
                pedido.IGV += (pedido.Subtotal * 12) / 100;
                pedido.Total += pedido.Subtotal + ((pedido.Subtotal * pedido.IGV) / 100);
                //pedido.Cliente = cli;
                factura.Pedido = pedido;

                //db.Pedidoes.Add(pedido);
                db.DetallePedidoes.Add(factura);
            }

            db.SaveChanges();
            return RedirectToAction("Index", "Pedidos");
        }
    }




}