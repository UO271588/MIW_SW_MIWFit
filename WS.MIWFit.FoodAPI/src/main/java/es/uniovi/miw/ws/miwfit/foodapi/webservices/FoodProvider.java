package es.uniovi.miw.ws.miwfit.foodapi.webservices;

import es.uniovi.miw.ws.miwfit.foodapi.model.Food;

import java.util.ArrayList;
import java.util.List;

public class FoodProvider implements IFoodProvider{

    private List<Food> foods;

    public FoodProvider(){
        foods = new ArrayList<Food>();
        foods.add(new Food("Macarrones a la boloñesa", 569 ));
        foods.add(new Food("Arroz con pollo", 235 ));
        foods.add(new Food("Pollo con cuscus", 0 ));
        foods.add(new Food("Quesadillas de pavo y aguacate", 0 ));
        foods.add(new Food("Ramen de ternera", 0 ));
        foods.add(new Food("Hamburguesa de ternera", 0 ));
        foods.add(new Food("Berenjenas rellenas", 0 ));
        foods.add(new Food("Ensalada de garbanzos", 0 ));
        foods.add(new Food("Ensalada de pasta", 0 ));
        foods.add(new Food("Salmón a la plancha", 0 ));
        foods.add(new Food("Bocadillo de albondigas", 0 ));
        foods.add(new Food("Kebab de ternera", 0 ));
        foods.add(new Food("Tortitas proteicas", 0 ));
        foods.add(new Food("Brownie proteico", 0 ));
        foods.add(new Food("Natillas", 0 ));
        foods.add(new Food("Yogurt", 0 ));
    }


    @Override
    public List<Food> getFood(double calories) {

        return foods;
    }
}
