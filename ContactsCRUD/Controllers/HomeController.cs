using ContactsCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactsCRUD.Controllers
{
    public class HomeController : Controller
    {
        readonly ContactDB contactDB = new ContactDB();
        public ActionResult Index() => View();
        public JsonResult List() => Json(contactDB.ListAll(), JsonRequestBehavior.AllowGet);
        public JsonResult Add(Contact contact) => Json(contactDB.Add(contact), JsonRequestBehavior.AllowGet);
        public JsonResult GetById(int Id) => Json(contactDB.ListAll().Find(x => x.Id.Equals(Id)), JsonRequestBehavior.AllowGet);
        public JsonResult Update(Contact contact) => Json(contactDB.Update(contact), JsonRequestBehavior.AllowGet);
        public JsonResult Delete(int Id) => Json(contactDB.Delete(Id), JsonRequestBehavior.AllowGet);

    }
}