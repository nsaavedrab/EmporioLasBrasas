using BarCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BarCode.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BarCodeModel model = new BarCodeModel();

            return View(model);
        }

        public ActionResult BarCode(BarCodeModel model)
        {
            if(model.Peso != null)
            {
                model.Peso = model.Peso.Replace(".", ",");
            }
            
            model.GenerateBarCode();
            return View(model);
        }


    }
}