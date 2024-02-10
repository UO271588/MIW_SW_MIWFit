namespace WS.MIWFit.Data.Model
{
    public class FitStats
    {
        public int Id { get; set; }
        public long Weight { get; set; }
        public long Height { get; set; }
        public long IMC { get; set; }
        public string Activity { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public User User { get; set; } = new User();

    }
}
