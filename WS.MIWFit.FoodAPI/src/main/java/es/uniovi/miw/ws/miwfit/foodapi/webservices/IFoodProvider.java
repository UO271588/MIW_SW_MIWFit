package es.uniovi.miw.ws.miwfit.foodapi.webservices;

import es.uniovi.miw.ws.miwfit.foodapi.excepciones.CaloriesMustBePositiveException;
import es.uniovi.miw.ws.miwfit.foodapi.model.Food;
import jakarta.jws.WebMethod;
import jakarta.jws.WebService;
import jakarta.jws.soap.SOAPBinding;

import java.util.List;

@WebService
@SOAPBinding(style = SOAPBinding.Style.DOCUMENT)
public interface IFoodProvider {

    @WebMethod
    public List<Food> getFood(double calories) throws CaloriesMustBePositiveException;
}

