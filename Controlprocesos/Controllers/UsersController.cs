using Controlprocesos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controlprocesos.Controllers {
    [Authorize(Roles = "Manager")]
    public class UsersController : Controller {

        private CP db = new CP();

        public ActionResult Index() {
            return View(db.vwUsers.ToList());
        }

    }
}
