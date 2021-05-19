using Microsoft.AspNetCore.Mvc;
using System.Collection.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;


namespace Restaurant.Controllers
{
  public class EstablishmentController : Controller
  {
    private readonly RestaurantContext _db;

    public EstablishmentController(EstablishmentContext db)
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
      return View();
    }
    [HttpPost]
    public ActionResult Create(Establishment establishment)
    {
      db.Establishments.Add(establishment);
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
    [HttpPost]
    public ActionResult Delete(int ident)
    {
      Establishment thisEstablishment = _db.Establishments.FirstOrDefault(establishment => establishment.EstablishmentId == ident);
      _db.Establishments.Remove(thisEstablishment);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}