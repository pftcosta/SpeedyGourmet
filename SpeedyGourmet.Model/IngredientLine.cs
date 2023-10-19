namespace SpeedyGourmet.Model
{
    public class IngredientLine
    {
        public int Id { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
        public long Quantity { get; set; }
        public Measure Measure { get; set; }
    }
}