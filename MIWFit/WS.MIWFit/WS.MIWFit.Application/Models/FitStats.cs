namespace WS.MIWFit.Application.Models
{
    public class FitStats
    {
        public string Activity{  get; set; } = string.Empty;
        public double Height { get; set; }
        public double Calories { get; set; }
        public double Deficit { get; set; }
        public double Imc { get; set; }
        public double Weight {  get; set; }
        public double Superavit {  get; set; }
        public DateTime Date { get; set; }
    }
}
