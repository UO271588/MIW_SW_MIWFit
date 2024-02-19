namespace WS.MIWFit.Data.Model
{
    public class FitStats
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Imc { get; set; }
        public double Calories { get; set; }
        public double Superavit { get; set; }
        public double Deficit { get; set; }
        public string Activity { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public User User { get; set; } = new User();

    }
}
