namespace WS.MIWFit.Data.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public ICollection<FitStats> FitStats { get; set; } = new List<FitStats>();
    }
}
