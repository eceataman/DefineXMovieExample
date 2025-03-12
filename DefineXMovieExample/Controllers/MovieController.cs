using DefineXMovieExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;  // HttpClient için eklenmesi gerekir
using System.Text.Json; // JSON serileştirme için
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;

namespace DefineXMovieExample.Controllers
{
    public class MovieController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Movie> MovieList = new List<Movie>(); // Film listesi oluşturuluyor

            using (var httpClient = new HttpClient()) // HttpClient başlatılıyor
            {
                using (var response = await httpClient.GetAsync("https://localhost:7150/api/movie")) // API'ye GET isteği atılıyor
                {
                    if (response.IsSuccessStatusCode) // API başarılı şekilde döndü mü?
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync(); // API cevabı string olarak alınıyor

                        MovieList = System.Text.Json.JsonSerializer.Deserialize<List<Movie>>(apiResponse, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true // JSON'daki küçük/büyük harf duyarlılığını kapat
                        });
                    }
                    else
                    {
                        // API başarısız dönerse hata mesajı gösterebiliriz
                        ModelState.AddModelError(string.Empty, "API isteği başarısız.");
                    }
                }
            }

            return View(MovieList); // MovieList verisini View'e gönder
        }
        public async Task<IActionResult> MovieDetails(int id)
        {
            Movie editMovie = new Movie();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7150/api/movie/{id}"))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string movieDetail = await response.Content.ReadAsStringAsync();
                        editMovie = JsonConvert.DeserializeObject<Movie>(movieDetail);
                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode; // ✅ ViewBag doğru tanımlandı mı?
                    }
                }
            }

            return View(editMovie);
        }
    }
    
   

}



