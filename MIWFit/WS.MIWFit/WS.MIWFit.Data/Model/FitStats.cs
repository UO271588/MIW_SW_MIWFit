using System.Security.Cryptography.X509Certificates;

namespace WS.MIWFit.Data.Model
{
    public class FitStats
    {
        public int Id { get; set; }
        public long Weigth { get; set; }
        public long Heigth { get; set; }
        public long IMC { get; set; }
        public string Activity { get; set; } = string.Empty;
        
    }
}
