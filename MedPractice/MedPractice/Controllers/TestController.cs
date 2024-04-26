using Microsoft.AspNetCore.Mvc;

namespace MedPractice.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Form1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form1(String name,String book,double price,int Qty)
        {
            
            HttpContext.Session.SetString("name", name.ToString());
            HttpContext.Session.SetString("book", book.ToString());
            HttpContext.Session.SetString("price", price.ToString());
            HttpContext.Session.SetString("Qty", Qty.ToString());
            if (name != "" && book != "" && name != null && book != null)
            {
                return RedirectToAction("Form2");
            }
            ViewBag.result = "please fill every input";
            return View();
            }

        [HttpGet]
        public IActionResult Form2()
        {
            ViewBag.name = HttpContext.Session.GetString("name");
            return View();
        }

        [HttpPost]
        public IActionResult Form2(String gender,String Country)
        {
            double result = double.Parse(HttpContext.Session.GetString("price")) * double.Parse(HttpContext.Session.GetString("Qty"));

            if (Country == "JOR")
                result += 0;
            else if (Country == "SYR")
                result += 30;
            else
                result += 20;

            HttpContext.Session.SetString("result", result.ToString());
            ViewBag.name = HttpContext.Session.GetString("name");

            TempData["gender"] = gender.ToString();
            TempData["cntry"] = Country.ToString();
            return RedirectToAction("Form3");
        }

        [HttpGet]
        public IActionResult Form3()
        {
            ViewBag.name = HttpContext.Session.GetString("name");
            ViewBag.book = HttpContext.Session.GetString("book");
            ViewBag.price = HttpContext.Session.GetString("price");
            ViewBag.qty = HttpContext.Session.GetString("Qty");
            ViewBag.result = HttpContext.Session.GetString("result");
            return View();
        }

        [HttpPost]
        [ActionName("Form3")]
        public IActionResult backtoFormOne()
        {
            return RedirectToAction("Form1");
        }
    }
}
