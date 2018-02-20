﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ejemplolab1.DBContest;
using ejemplolab1.Models;
using System.Net;
using System.IO;
using directorios = System.IO;


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
        public ActionResult Create([Bind(Include="Jugadorid,Nombre,Apellido,Salario,Posicion,Club")]Jugador jugador)
        {
            try
            {
                // TODO: Add insert logic here
                jugador.Jugadorid = ++db.IDActual;
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
            Jugador jugadorBuscado = db.Jugadores.Find(x => x.Jugadorid == id);

            if (jugadorBuscado == null)
            {

                return HttpNotFound();
            }
            return View(jugadorBuscado);
        }

        // POST: Jugador/Edit/5
        [HttpPost]
    [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Jugadorid,Nombre,Apellido,Salario,Posicion,Club")]Jugador jugador)
        {
            try
            {
                // TODO: Add update logic here
                Jugador jugadorbuscado = db.Jugadores.Find(x => x.Jugadorid == jugador.Jugadorid);
                if (jugadorbuscado == null)
                {
                    return HttpNotFound();
                }
                jugadorbuscado.Nombre = jugador.Nombre;
                jugadorbuscado.Apellido = jugador.Apellido;
                jugadorbuscado.Salario = jugador.Salario;
                jugadorbuscado.Posicion = jugador.Posicion;
                jugadorbuscado.Club = jugador.Club;
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: Jugador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jugador jugadorBuscado = db.Jugadores.Find(x => x.Jugadorid == id);

            if (jugadorBuscado == null)
            {

                return HttpNotFound();
            }
            return View(jugadorBuscado);
        }

        // POST: Jugador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                db.Jugadores.Remove(db.Jugadores.First(x => x.Jugadorid == id));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
