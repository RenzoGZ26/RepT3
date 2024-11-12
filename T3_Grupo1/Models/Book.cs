using Microsoft.ML.Data;

namespace T3_Grupo1.Models
{
    public class Book
    {
        [LoadColumn(0)]  // Columna 0 en el CSV
        public string Title { get; set; }

        [LoadColumn(1)]  // Columna 1 en el CSV
        public string Author { get; set; }

        [LoadColumn(2)]  // Columna 2 en el CSV
        public string Genre { get; set; }

        [LoadColumn(3)]  // Columna 3 en el CSV
        public string Description { get; set; }

        public string CombinedFeatures => $"{Title} {Author} {Genre} {Description}";  // Concatenación de las características
    }

    public class BookPrediction
    {
        public string Title { get; set; }
        public string PredictedTitle { get; set; }
    }
}
