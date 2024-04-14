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
            string result;

            if(name == "ASP" && password == "ASP")
            {
                ViewBag.result = "Valid User";
            }
            else
            {
                ViewBag.result = "Invalid User";
            }

            ViewBag.name = name;
            ViewBag.password = password;

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

        [HttpGet]
        public IActionResult Form7()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form7(string productName, double price , int Count)
        {
            double Total = price * Count;


            TempData["Total"] = Total.ToString();
            TempData["productName"] = productName.ToString();
            TempData["price"] = price.ToString();
            TempData["Count"] = Count.ToString();

            return RedirectToAction("Form8");
        }

        [HttpGet]
        public IActionResult Form8()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Form8")]
        public IActionResult BackToForm7()
        {
            return RedirectToAction("Form7");
        }

        [HttpGet]
        public IActionResult Form9()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form9(string userName,string productName)
        {
            HttpContext.Session.SetString("userName" , userName.ToString());
            HttpContext.Session.SetString("productName", productName.ToString());

            return RedirectToAction("Form10");
        }

        [HttpGet]
        public IActionResult Form10()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form10(double price,int count)
        {   
            double total = price * count;

            HttpContext.Session.SetString("total", total.ToString());
            HttpContext.Session.SetString("price", price.ToString());
            HttpContext.Session.SetString("count", count.ToString());



            return RedirectToAction("Form11");
        }

        [HttpGet]
        public IActionResult Form11()
        {

            ViewBag.userName =  HttpContext.Session.GetString("userName");
            ViewBag.productName = HttpContext.Session.GetString("productName");
            ViewBag.total = HttpContext.Session.GetString("total");
            ViewBag.price = HttpContext.Session.GetString("price");
            ViewBag.count = HttpContext.Session.GetString("count");

            return View();
        }


        [HttpPost]
        [ActionName("Form11")]
        public IActionResult BacktoForm9()
        {
            return RedirectToAction("Form9");
        }


    }
}
