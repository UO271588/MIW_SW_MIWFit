package es.uniovi.miw.ws.calculadoraimc.calculadoraimc.webservices;

import es.uniovi.miw.ws.calculadoraimc.calculadoraimc.model.ResultadoIMC;
import jakarta.jws.WebService;

@WebService
public class CalculatorIMC implements ICalculatorIMC{
    @Override
    public ResultadoIMC calcularIMC(double peso, double altura, String sexo, String actividad) {
        ResultadoIMC resultadoIMC = new ResultadoIMC();
        resultadoIMC.setPeso(peso);
        resultadoIMC.setAltura(altura);
        resultadoIMC.setSexo(sexo);
        resultadoIMC.setActividad(actividad);

        altura /= 100; //Dividimos para usar la altura en metros
        double imc = (peso) / (altura * altura);
        double pesoIdeal = 22 * (altura * altura);

        resultadoIMC.setImc(imc);
        resultadoIMC.setPesoIdeal(pesoIdeal);

        // Calcular MB
        double mb = (sexo.equals("Hombre")) ? 66.5 + (13.75 * peso) + (5.003 * altura * 100) - (6.75 * 25) : 655.1 + (9.563 * peso) + (1.85 * altura * 100) - (4.676 * 25);

        double factorActividad = obtenerFactorActividad(actividad);
        double calorias = mb * factorActividad;
        double caloriasSuperavit = calorias * 1.2; // Suponiendo superávit del 20%
        double caloriasDeficit = calorias * 0.8; // Suponiendo déficit del 20%

        resultadoIMC.setCalorias(calorias);
        resultadoIMC.setSuperavit(caloriasSuperavit);
        resultadoIMC.setDeficit(caloriasDeficit);

        return resultadoIMC;
    }

    private double obtenerFactorActividad(String actividad) {
        switch (actividad) {
            case "Sedentario":
                return 1.2;
            case "Ligero":
                return 1.375;
            case "Moderado":
                return 1.55;
            case "Activo":
                return 1.725;
            case "Muy activo":
                return 1.9;
            default:
                return 1.2; // Por defecto, sedentario
        }
    }
}
