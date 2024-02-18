namespace WS.MIWFit.Application.Models
{
    public class ResultadoIMC
    {
        public double Peso { get; set; }
        public double Altura { get; set; }
        public string Sexo { get; set; } = string.Empty;
        public string Actividad { get; set; } = string.Empty;
        public double Imc { get; set; }
        public double PesoIdeal { get; set; }
        public double Calorias { get; set; }
        public double Superavit { get; set; }
        public double Deficit { get; set; }
    }
}
