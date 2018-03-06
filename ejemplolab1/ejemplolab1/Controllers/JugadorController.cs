using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ejemplolab1.DBContest;
using ejemplolab1.Models;
using System.Net;
using System.IO;
using System.Web.UI.WebControls;
 
namespace ejemplolab1.Controllers
{
    public class JugadorController : Controller
    {
        DefaultConnection db =  DefaultConnection.getInstance;
     
        // GET: Jugador
        public ActionResult Index()
        {
     
            return View(db.Jugadores.ToList());
        }

        // GET: Jugador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Jugador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jugador/Create
        [HttpPost]
        public ActionResult Create([Bind(Include="jugadorid,nombre,apellido,salario,posiscion")]Jugador jugador)
        {
            try
            {
                // TODO: Add insert logic here
                jugador.jugadorid = ++db.IDActual;
                db.Jugadores.Add(jugador);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jugador jugadorBuscado = db.Jugadores.Find(x => x.jugadorid == id);

            if (jugadorBuscado == null)
            {

                return HttpNotFound();
            }
            return View(jugadorBuscado);
        }

        // POST: Jugador/Edit/5
        [HttpPost]
    [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="jugadorid,nombre,apellido,salario,posiscion")]Jugador jugador)
        {
            try
            {
                // TODO: Add update logic here
                Jugador jugadorbuscado = db.Jugadores.Find(x => x.jugadorid == jugador.jugadorid);
                if (jugadorbuscado == null)
                {
                    return HttpNotFound();
                }
                jugadorbuscado.nombre = jugador.nombre;
                jugadorbuscado.apellido = jugador.apellido;
                jugadorbuscado.salario = jugador.salario;
                jugadorbuscado.posiscion = jugador.posiscion;
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        public ActionResult CargarArchivo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CargarArchivo(HttpPostedFileBase upload)
        {
            try
            {

                 string filePath = string.Empty;
                 if (upload != null)
        {
            string path = Server.MapPath("~/Uploads/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
 
            filePath = path + Path.GetFileName(upload.FileName);
            string extension = Path.GetExtension(upload.FileName);
            upload.SaveAs(filePath);
 
            //Read the contents of CSV file.
            string csvData = System.IO.File.ReadAllText(filePath);
 
            //Execute a loop over the rows.
            foreach (string linea in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(linea))
                {
                    string[] datos = linea.Split(';', ';', ';');


                    Jugador jugadorinsert = new Jugador();
                    jugadorinsert.nombre = datos[0].ToString();
                    jugadorinsert.apellido = datos[1].ToString();
                    jugadorinsert.salario = Convert.ToDouble(datos[2].ToString());
                    jugadorinsert.posiscion = datos[3].ToString();

                    db.Jugadores.Add(jugadorinsert);
                }
            }
        }
 
      




             }
            catch (Exception ex)
            {
                ViewBag.mensaje = "Se produjo un error : " + ex.Message;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
          
        }

        // GET: Jugador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Jugador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
