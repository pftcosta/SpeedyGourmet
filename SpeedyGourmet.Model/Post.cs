namespace SpeedyGourmet.Model
{
    public class Post
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Recipe Recipe { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; } // 0 to 10 stars
    }
}
