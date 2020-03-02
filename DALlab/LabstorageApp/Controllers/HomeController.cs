using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DALlab;

namespace LabstorageApp.Controllers
{
    public class HomeController : Controller
    {
        Repository o = new Repository();

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///LOGIN CONTROLLER
        // GET: Home
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(detail d)
        {
            try
            {
                // TODO: Add insert logic here
               bool status= o.login(d);
                if(status==true)
                {
                    return RedirectToAction("Displayrecords");
                }
                else
                {
                    return RedirectToAction("loginerror");
                }
                
            }
            catch
            {
                return View();
            }
        }

        //// GET: Home/Create
        //public ActionResult Registeruser()
        //{
        //    return View();
        //}

        //// POST: Home/Create
        //[HttpPost]
        //public ActionResult Registeruser(detail d)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        o.signup(d);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///OPERATIONS CONTROLLERS
///1.DISPLAY
///2.ADD
///3.SEARCH
///4.EDIT
///5.DETAILS
///6.DELETE

        public ActionResult Displayrecords()
        {
            //List<searchitem_Result> list = new List<searchitem_Result>();
            //list = o.searchitem(s);
            List<record> list = new List<record>();
            list = o.display();
            return View(list);

        }

        // GET: Home/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Add(record r)
        {
            try
            {
                // TODO: Add insert logic here
                bool status=o.additem(r);
                if (status)
                    return RedirectToAction("Displayrecords");
                else
                    return RedirectToAction("Error");
            }
            catch
            {
                return View();
            }
        }

        
        
        public ActionResult Search(string s)
        {
            List<searchitem_Result> list = new List<searchitem_Result>();
            list = o.searchitem(s);
            return View(list);
        }


        // GET: Home/UseItem/id
        public ActionResult UseItem()
        {
            using (var db = new LabStorageEntities())
            {

                return View();
            }
        }

        // POST: Home/UseItem/id
        [HttpPost]
        public ActionResult UseItem(record r)
        {
            try
            {
               // o.modifyitem(id, r);
                return RedirectToAction("Displayrecords");
            }
            catch
            {
                return View();
            }
        }


        // GET: Home/Edit/id
        public ActionResult Edit(int id)
        {
            using (var db = new LabStorageEntities())
            {

                return View(db.records.Where(s=>s.id==id).FirstOrDefault());
            }
        }

        // POST: Home/Edit/id
        [HttpPost]
        public ActionResult Edit(int id, record r)
        {
            try
            {
                o.modifyitem(id, r);
                return RedirectToAction("Displayrecords");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Details(int id)
        {
            using (var db = new LabStorageEntities())
                return View(db.records.Where(m => m.id == id).FirstOrDefault());
        }


        // GET: Home/Delete/id
        public ActionResult Delete(int id)
        {
            using (var db = new LabStorageEntities())
            {
                return View(db.records.Where(m=> m.id== id).FirstOrDefault());
            }
                
        }

        // POST: Home/Delete/id
        [HttpPost]
        public ActionResult Delete(int id, record r)
        {
            try
            {
                o.deleteitem(id, r);
                return RedirectToAction("Displayrecords");
            }
            catch
            {
                return View();
            }
        }

/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//ERRORS CONTROLLERS
///1. LOGIN ERROR
///2. COMMON ERROR
      
        public ActionResult loginerror()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

 /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 ///1. ABOUT
 ///2.CONTACT

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
