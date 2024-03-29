package es.uniovi.miw.ws.miwfit.foodapi.excepciones;

import jakarta.xml.ws.WebFault;

@WebFault
public class CaloriesMustBePositiveException extends Exception {

    private String faultCode;
    private String faultString;
    public CaloriesMustBePositiveException(){
        super("Calories can not be negative");
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
