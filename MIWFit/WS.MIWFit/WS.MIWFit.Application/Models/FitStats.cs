namespace WS.MIWFit.Application.Models
{
    public class FitStats
    {
        public string Actividad {  get; set; } = String.Empty;

        public double Altura { get; set; }

        public double Calorias { get; set; }

        public double Deficit { get; set; }

        public double Imc { get; set; }
        
        public double Peso {  get; set; }
        
        public double PesoIdeal {  get; set; }

        public string Sexo { get; set; } = String.Empty;
        
        public double Superavit { get; set; }
    }
}
