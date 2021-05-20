using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using System.Collections.Generic;
using System.Linq;


namespace Restaurant.Controllers
{
  public class EstablishmentsController : Controller
  {
    private readonly RestaurantContext _db;

    public EstablishmentsController(RestaurantContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Establishment> listOfEstablishments = _db.Establishments.Include(establishment => establishment.Cuisine).ToList();
      return View(listOfEstablishments);
    }

    public ActionResult Create()
    {
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "CuisineName");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Establishment establishment)
    {
      _db.Establishments.Add(establishment);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Establishment thisEstablishment = _db.Establishments.FirstOrDefault(establishment => establishment.EstablishmentId == id);
      return View(thisEstablishment);
    }

    public ActionResult Edit(int id)
    {
      Establishment thisEstablishment = _db.Establishments.FirstOrDefault(establishment => establishment.EstablishmentId == id);
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "CuisineName");
      return View(thisEstablishment);
    }

    [HttpPost]
    public ActionResult Edit(Establishment establishment)
    {
      _db.Entry(establishment).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      Establishment thisEstablishment = _db.Establishments.FirstOrDefault(establishment => establishment.EstablishmentId == id);
      return View(thisEstablishment);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Establishment thisEstablishment = _db.Establishments.FirstOrDefault(establishment => establishment.EstablishmentId == id);
      _db.Establishments.Remove(thisEstablishment);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}