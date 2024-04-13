using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class FormsController : Controller
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
        public IActionResult Form1(int n1,int n2,string b1)
        {
            int result = 0;
            switch (b1)
            {
                case "AVG":
                    result = n1+n2;
                break;
                case "MAX":
                    result = Math.Max(n1, n2);
                break ;

                case "MIN":
                    result= Math.Min(n1, n2);  
                break;
            }

            ViewBag.result = result;

            return View();
        }

        [HttpGet]
        public IActionResult Form2()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Form2(int n1,int n2,string Op)
        {
            int result = 0;
            switch (Op)
            {
                case "Add":
                    result = n1 + n2;
                    break;
                case "Sub":
                    result = n1 - n2;
                    break;
                case "Div":
                    result = n1 / n2;
                    break;
            }

            ViewBag.result = result;
            ViewBag.n1 = n1;
            ViewBag.n2 = n2;

            return View();
        }

        [HttpGet]
        public IActionResult Form3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form3(int n1, int n2,int n3)
        {
            int secondMin;

            int min = Math.Min(n1, Math.Min(n2, n3));

            if (min == n1)
            {
                secondMin = Math.Min(n2, n3);
            }
            else if (min == n2)
            {
                secondMin = Math.Min(n1, n3);
            }
            else
            {
                secondMin = Math.Min(n1, n2);
            }

            ViewBag.secondMin = secondMin;
            ViewBag.n1 = n1;
            ViewBag.n2 = n2;
            ViewBag.n3 = n3;
            return View();
        }

        [HttpGet]
        public IActionResult Form4()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form4(string name,string password)
        {

            return View();
        }

        [HttpGet]
        public IActionResult Form5()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form5(int n1,int n2 , int n3, string b1)
        {
            int result = 0;
            if (b1 == "Max") {
            result = Math.Max(n1 , Math.Max(n2, n3));
            }
            else if(b1 == "Average")
            {
                result = (n1+ n2 + n3) / 3;
            }


            TempData["result"] = result.ToString();
            TempData["b1"] = b1.ToString();

            return RedirectToAction("Form6");
        }

        [HttpGet]
        public IActionResult Form6()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Form6")]
        public IActionResult BackToForm5()
        {
            return RedirectToAction("Form5");
        }

    }
}
