namespace SpeedyGourmet.Model
{
    public class Favourite
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Recipe Recipe { get; set; }
    }
}
