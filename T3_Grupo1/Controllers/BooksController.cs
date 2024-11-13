using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using T3_Grupo1.Services;

namespace T3_Grupo1.Controllers
{
    public class BooksController : Controller
    {
        private readonly GeminiRecommendationService _geminiRecommendationService;

        public BooksController(GeminiRecommendationService geminiRecommendationService)
        {
            _geminiRecommendationService = geminiRecommendationService;
        }

        public async Task<IActionResult> RecommendBooks(string bookTitle)
        {
            if (string.IsNullOrEmpty(bookTitle))
            {
                ViewBag.Error = "Por favor, ingresa un título de libro.";
                return View("Index");
            }

            // Obtener recomendaciones utilizando Gemini
            var recommendations = await _geminiRecommendationService.GetBookRecommendationsAsync(bookTitle);

            // Pasar las recomendaciones a la vista
            ViewBag.Recommendations = recommendations;
            ViewBag.BookTitle = bookTitle; // Para mostrar el título del libro en la vista

            return View("Recommendations");
        }
    }


}
