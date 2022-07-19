using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bakery.Models;

namespace Bakery.Controllers
{
  public class BakeryController : Controller
  {

      [HttpGet("/menu")]
      public ActionResult Index()
      {
        List<Item> menu = Item.GetAll();
        return View(menu);
      }

      [HttpPost("/menu")]
      public ActionResult CreateForm()
      {
        return View();
      }

  }
}