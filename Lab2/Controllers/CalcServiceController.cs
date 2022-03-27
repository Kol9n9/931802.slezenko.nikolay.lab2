using Microsoft.AspNetCore.Mvc;
using Lab2.Models;
namespace Lab2.Controllers
{
    public class CalcServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Manual()
        {
            if(Request.Method == "POST")
            {
                try
                {
                    var model = new CalcResult(int.Parse(HttpContext.Request.Form["FirstValue"]), int.Parse(HttpContext.Request.Form["SecondValue"]), HttpContext.Request.Form["Operation"]);
                    ViewBag.Result = model.Print();
                }
                catch
                {
                    ViewBag.Result = "Invalid input";
                }
                return View("Result");
            }
            return View("ViewWithHtmlHelpers");
        }

        [HttpGet]
        [ActionName("ManualWithSeparateHandlers")]
        public IActionResult ManualWithSeparateHandlersGet()
        {
            return View("ViewWithHtmlHelpers");
        }


        [HttpPost]
        [ActionName("ManualWithSeparateHandlers")]
        public IActionResult ManualWithSeparateHandlersPost()
        {
            try
            {
                var model = new CalcResult(int.Parse(HttpContext.Request.Form["FirstValue"]), int.Parse(HttpContext.Request.Form["SecondValue"]), HttpContext.Request.Form["Operation"]);
                ViewBag.Result = model.Print();
            }
            catch
            {
                ViewBag.Result = "Invalid input";
            }

            return View("Result");
        }

        [HttpGet]
        public IActionResult ModelBindingInParameters()
        {
            return View("ViewWithHtmlHelpers");
        }

        [HttpPost]
        public IActionResult ModelBindingInParameters(int firstValue, string operation, int secondValue)
        {
            if (ModelState.IsValid)
            {
                var model = new CalcResult(firstValue, secondValue, operation);
                ViewBag.Result = model.Print();
            }
            else
            {
                ViewBag.Result = "Invalid input";
            }

            return View("Result");
        }

        [HttpGet]
        public IActionResult ModelBindingInSeparateModel()
        {
            return View("ViewWithTagHelpers");
        }

        [HttpPost]
        public IActionResult ModelBindingInSeparateModel(CalcResult model)
        {
            ViewBag.Result = ModelState.IsValid
                ? model.Print()
                : "Invalid input";

            return View("Result");
        }
    }
}
