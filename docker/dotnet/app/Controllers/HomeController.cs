using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace app.Controllers {
    public class HomeController : AbstractController {
        public HomeController () { }

        public IActionResult Index () {
            return View ();
        }

        [HttpGet]
        public IActionResult Sample () {
            return Json ("chamara");
        }

        [HttpPost]
        public IActionResult Calculate (CalculateModel Model) {
            var result = new CalculateResultModel ();

            // validate
            var value1 = 0;
            if (int.TryParse (Model.Value1, out value1) == false) {
                result.errorFlg = true;
                result.errorMessage = "value1 is number only";
                return Json (result);
            }

            var value2 = 0;
            if (int.TryParse (Model.Value2, out value2) == false) {
                result.errorFlg = true;
                result.errorMessage = "value2 is number only";
                return Json (result);
            }

            result.Result = value1 + value2;
            return Json (result);
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}