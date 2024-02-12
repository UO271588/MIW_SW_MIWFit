package es.uniovi.miw.ws.calculadoraimc.calculadoraimc.webservices;

import es.uniovi.miw.ws.calculadoraimc.calculadoraimc.model.ResultadoIMC;
import jakarta.jws.WebMethod;
import jakarta.jws.WebService;
import jakarta.jws.soap.SOAPBinding;

@WebService
@SOAPBinding(style = SOAPBinding.Style.DOCUMENT)
public interface ICalculatorIMC {
    @WebMethod
    public ResultadoIMC calcularIMC(double peso, double altura, String sexo, String actividad);
}
