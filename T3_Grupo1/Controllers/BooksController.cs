using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using T3_Grupo1.Datos;
using T3_Grupo1.Models;

namespace T3_Grupo1.Controllers
{
    public class BooksController : Controller
    {
        private readonly RecommendationEngine _recommendationEngine;

        public BooksController()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "books_data.csv");
            _recommendationEngine = new RecommendationEngine(filePath);  // Inicializamos el motor de recomendaciones
        }

        public IActionResult RecommendBooks(string bookTitle)
        {
            if (string.IsNullOrEmpty(bookTitle))
            {
                ViewBag.Message = "Por favor, ingrese un título de libro.";
                return View();
            }

            var recommendation = _recommendationEngine.PredictBookRecommendation(bookTitle);  // Obtener recomendación basada en el título
            ViewBag.RecommendedBook = recommendation.PredictedTitle;  // Mostrar la recomendación

            return View();
        }
    }
}




