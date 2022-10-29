using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PokemonDb;

namespace PokemonDb.Controllers
{
    public class PokemonController : Controller
    {
        private EFPokemonDbEntities1 db = new EFPokemonDbEntities1();     

        // GET: Pokemon
        public ActionResult Index(int? page, string search)
        {
            //use viewDta to take user input
            ViewData["Getpokemondetails"] = search;
            if (!string.IsNullOrEmpty(search))
            {
                List<pokemon> pokemon1 = db.pokemons.ToList();
                return View(pokemon1.Where(x => x.Name.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 3));
            }
            //var products = db.pokemons.OrderBy(x => x.Name);
            var pageNumber = page ?? 1;
            var pageSize = 10;
            var pokemon = db.pokemons.OrderBy(x => x.Name).ToPagedList(pageNumber, pageSize);
            return View(pokemon);

            }

        // GET: Pokemon/Legendary
        //[HttpGet]
        //Filter by legendaey
        public ActionResult Legendary()
        {

            var pokemon = db.pokemons.Where(e => e.Legendary == true).ToList();
            return View(pokemon);
        }

        //Filter by Speed
        public ActionResult FilterBySpeed(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 10;

            var pokemon = db.pokemons.OrderByDescending(x => x.Speed).ToPagedList(pageNumber, pageSize);
            return View(pokemon);

        }

        //Filter by Attack
        public ActionResult FilterByAttack(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 10;
            var pokemon = db.pokemons.OrderByDescending(x => x.Attack).ToPagedList(pageNumber, pageSize);
            return View(pokemon);
        }


        // GET: Pokemon/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pokemon pokemon = db.pokemons.Find(id);
            if (pokemon == null)
            {
                return HttpNotFound();
            }
            return View(pokemon);
        }

        // GET: Pokemon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pokemon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Type_1,Type_2,Total,HP,Attack,Defense,Sp_Atk,Sp_Def,Speed,Generation,Legendary")] pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                db.pokemons.Add(pokemon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pokemon);
        }

        // GET: Pokemon/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pokemon pokemon = db.pokemons.Find(id);
            if (pokemon == null)
            {
                return HttpNotFound();
            }
            return View(pokemon);
        }

        // POST: Pokemon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Type_1,Type_2,Total,HP,Attack,Defense,Sp_Atk,Sp_Def,Speed,Generation,Legendary")] pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pokemon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pokemon);
        }

        // GET: Pokemon/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pokemon pokemon = db.pokemons.Find(id);
            if (pokemon == null)
            {
                return HttpNotFound();
            }
            return View(pokemon);
        }

        // POST: Pokemon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            pokemon pokemon = db.pokemons.Find(id);
            db.pokemons.Remove(pokemon);
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
