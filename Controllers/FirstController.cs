using Microsoft.AspNetCore.Mvc;
using mvc.Services;

namespace mvc.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, IWebHostEnvironment env, ProductService productsService)
        {
            _env = env;
            _logger = logger;
            _productService = productsService;
        }

        public ActionResult CheckPath()
        {
            string contentRootPath = _env.ContentRootPath;
            string webRootPath = _env.WebRootPath;

            return Content(contentRootPath + "\n" + webRootPath);
        }
       
        public string Index()
        {
            // this.HttpContext
            // this.Request
            // this.Response
            // this.RouteData

            // this.User
            // this.ModelState
            // this.ViewData
            // this.ViewBag
            // this.Url
            // this.TempData
            _logger.LogWarning("Thong bao");
            _logger.LogError("Thong bao");
            _logger.LogDebug("Thong bao");
            _logger.LogCritical("Thong bao");
            _logger.LogInformation("Index Action");
            // Serilog

            return "Toi la index cua first";
        }

        public void Nothing()
        {
            _logger.LogInformation("Nothing Action");
            Response.Headers.Add("hi", "xin chao cac ban");
        }

        public object Anything() => DateTime.Now;

        public IActionResult Readme()
        {
            var content = @"
            Xin chao cac ban
            cac ban dang hoc ASP.NET MVC
            
            
            Vestow
            ";
            return Content(content, "text/html");

        }

        public IActionResult Bird()
        {
            //Startup.ContentRootPath
            string fliePath = Path.Combine(_env.ContentRootPath, "Files", "bird.jpg");
            var bytes = System.IO.File.ReadAllBytes(fliePath);

            return File(bytes, "image/jpg");
        }

        public IActionResult Iphone()
        {
            return Json(
                new {
                    productName = "Iphone X",
                    price = 1000
                }
            );
        }

        public IActionResult Privacy()
        {   
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("Chuyen huong den" + url);
            return LocalRedirect(url); // local ~ host
        }

        public IActionResult Google()
        {
            var url = "https://google.com";
            _logger.LogInformation("CHuyen huong den" + url);
            return Redirect(url);
        }

        public IActionResult HelloView(string username)
        {
            if(string.IsNullOrEmpty(username))
            username = "Guest";
            // View() -> Razor Engine, doc .cshtml (template) 
            //-----------------------------------------------
            // View(template) - tempplate duong dan tuyet doi toi .cshtml
            // View(template, model)
            // xinchao2 -> /View/First/xinchao2.cshtml
            // HelloView -> /View/First/HelloView.cshtml
            return View("Xinchao3", username);
        }

        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            return NotFound();
            // /View/First/ViewProduct.cshtml
            // /MyView/First/ViewProduct.cshtml
            // Model
            // return View(product);

            // ViewData
            this.ViewData["product"] = product;
            ViewData["Title"] = product.Name;
            return View("ViewProduct2");
        }
    // IActionResult
    //     Kiểu trả về             | Phương thức
    // ------------------------------------------------
    // ContentResult               | Content()
    // EmptyResult                 | new EmptyResult()
    // FileResult                  | File()
    // ForbidResult                | Forbid()
    // JsonResult                  | Json()
    // LocalRedirectResult         | LocalRedirect()
    // RedirectResult              | Redirect()
    // RedirectToActionResult      | RedirectToAction()
    // RedirectToPageResult        | RedirectToRoute()
    // RedirectToRouteResult       | RedirectToPage()
    // PartialViewResult           | PartialView()
    // ViewComponentResult         | ViewComponent()
    // StatusCodeResult            | StatusCode()
    // ViewResult                  | View()
    }
}