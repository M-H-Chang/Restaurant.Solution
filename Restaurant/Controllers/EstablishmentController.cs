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
  }
}