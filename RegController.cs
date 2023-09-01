using Newtonsoft.Json;
using StudentMvcProject.Models;
using StudentMvcProject.Serivce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentMvcProject.Controllers
{
    public class RegController : Controller
    {
        // GET: Reg
        public ActionResult RegistrationForm()
        {
            return View();
        }
        RegService Rs = new RegService();
        public void PostData(RegModel objmodel)
        {
            try
            {
                Rs.RegInsertData(objmodel);
            }
            catch
            {
                throw;
            }

        }
        public JsonResult GetItemData()
        {
            try
            {
                var dataItem = JsonConvert.SerializeObject(Rs.GetData());
                return Json(dataItem, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                throw;
            }

        }
        public JsonResult GetbyId(RegModel objmodel)
        {
            try
            {
                var dataItem = JsonConvert.SerializeObject(Rs.GetDataById(objmodel));
                return Json(dataItem, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                throw;
            }
        }
        public void DeleteById(RegModel objmodel)
        {
            try
            {
                Rs.RegDeleteData(objmodel);
            }
            catch
            {
                throw;
            }
        }
        public void UpdateById(RegModel objmodel)
        {
            try
            {
                Rs.RegUpdateData(objmodel);
            }
            catch
            {
                throw;
            }
        }
    }
}