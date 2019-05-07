using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ProjectName.Controllers
{
  public class ProjectNameController : Controller
  {

    [Route("/animals")]
    public ActionResult Index() { return View(); }
  }
}
