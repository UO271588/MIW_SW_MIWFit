package es.uniovi.miw.ws.miwfit.calculadoraimc.excepciones;

import es.uniovi.miw.ws.miwfit.calculadoraimc.model.ResultadoIMC;
import jakarta.xml.ws.WebFault;

@WebFault
public class InvalidDataException extends Exception {

    private String faultCode;
    private String faultString;
    public InvalidDataException(ResultadoIMC resultadoIMC){
        super(resultadoIMC.getErrorMessage());
        this.faultString = getMessage();
        this.faultCode = "412 Precondition Failed";
    }

    public String getFaultCode() {
        return faultCode;
    }

    public void setFaultCode(String faultCode) {
        this.faultCode = faultCode;
    }

    public String getFaultString() {
        return faultString;
    }

    public void setFaultString(String faultString) {
        this.faultString = faultString;
    }
}
