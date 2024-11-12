namespace T3_Grupo1.Models
{
    public class BookData
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string CombinedFeatures => $"{Title} {Author} {Genre} {Description}";  // Concatenamos todos los campos de texto
    }

}
