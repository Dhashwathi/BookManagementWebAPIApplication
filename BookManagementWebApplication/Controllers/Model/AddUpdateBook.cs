namespace BookManagementWebApplication.Controllers.Model
{
    public class AddUpdateBook // for access the model
    {
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public int YearPublished { get; set; }
        public double BookPrice { get; set; }
        public string BookGenre { get; set; }
    }
}
