namespace SpeedyGourmet.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public User Author { get; set; }
        public List<IngredientLine> Ingredients { get; set; }
        public Category Category { get; set; }
        public Difficulty Difficulty { get; set; }
        public int PrepTime { get; set; } // in minutes
        public string PrepMethod { get; set; }
        public bool IsApproved { get; set; }
    }
}
