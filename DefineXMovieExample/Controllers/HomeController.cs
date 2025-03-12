using DefineXMovieExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mime;

namespace DefineXMovieExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        // 1️⃣ XML İçerik Döndüren Metot
        public ContentResult ContentResultMetot()
        {
            return Content("<root><ad>İbrahim</ad><soyad>Gökay</soyad><yas>45</yas></root>", "application/xml");
        }

        // 2️⃣ Dosya İndirme Metodu
        public FileContentResult FileContentResultMetot()
        {
            // Dosyayı bayt dizisi (byte array) olarak oku
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"C:\Users\Efe\Desktop\mvcornek.txt");

            // Kullanıcıya sunulacak dosya adı
            string fileName = "definex.txt";

            // Dosyayı "octet-stream" olarak döndür, böylece tarayıcı indirme başlatır
            return File(fileBytes, MediaTypeNames.Application.Octet, fileName);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About() {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
