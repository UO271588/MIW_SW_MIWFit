package es.uniovi.miw.ws.miwfit.foodapi.webservices;

import es.uniovi.miw.ws.miwfit.foodapi.excepciones.CaloriesMustBePositiveException;
import es.uniovi.miw.ws.miwfit.foodapi.model.Food;
import jakarta.jws.WebService;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

@WebService
public class FoodProvider implements IFoodProvider{

    private List<Food> foods;

    public FoodProvider(){
        foods = new ArrayList<Food>();
        foods.add(new Food("Macarrones a la boloñesa", "macarrones boloñesa", 600, "comida", 25, 15, 10, 200));
        foods.add(new Food("Arroz con pollo", "chicken rice",400, "comida", 30, 10, 5, 150));
        foods.add(new Food("Pollo asado", "pollo food", 300, "desayuno", 20, 10, 2, 100));
        foods.add(new Food("Quesadillas de pavo y aguacate", "quesadillas pavo aguacate", 500, "cena", 18, 20, 3, 180));
        foods.add(new Food("Ramen de ternera", "ramen ternera", 700, "comida", 35, 25, 8, 250));
        foods.add(new Food("Hamburguesa de ternera", "hamburguesa ternera",  800, "cena", 40, 30, 5, 300));
        foods.add(new Food("Berenjenas rellenas", "berenjenas rellenas", 450, "cena", 12, 15, 6, 200));
        foods.add(new Food("Ensalada de garbanzos", "ensalada garbanzos", 350, "comida", 15, 10, 5, 120));
        foods.add(new Food("Ensalada de pasta", "ensalada fria pasta", 400, "cena", 10, 15, 7, 180));
        foods.add(new Food("Salmón a la plancha", "salmon plancha verduras", 600, "cena", 30, 20, 2, 200));
        foods.add(new Food("Bocadillo de albondigas", "bocadillo albondigas 1", 350, "desayuno", 20, 10, 3, 120));
        foods.add(new Food("Kebab ternera", "donner kebab-wrap food",650, "comida", 25, 30, 4, 200));
        foods.add(new Food("Tortitas proteicas", "tortitas proteicas", 300, "desayuno", 15, 5, 4, 100));
        foods.add(new Food("Brownie", "brownie postre",500, "cena", 5, 25, 30, 150));
        foods.add(new Food("Natillas", "natillas food", 200, "postre", 5, 10, 20, 100));
        foods.add(new Food("Yogurt", "yogur dish", 250, "desayuno", 10, 5, 15, 150));
    }


    @Override
    public List<Food> getFood(double calories) throws CaloriesMustBePositiveException {
        if (calories <= 0) {
            throw new CaloriesMustBePositiveException();
        }

        List<Food> selectedFoods = new ArrayList<>();
        List<Food> desayunos = filterFoodsByType("desayuno");
        List<Food> comidas = filterFoodsByType("comida");
        List<Food> cenas = filterFoodsByType("cena");

        selectedFoods.add(selectFood(desayunos));
        selectedFoods.add(selectFood(comidas));
        selectedFoods.add(selectFood(cenas));

        // Ajustar las calorías para que se aproximen a la cantidad proporcionada
        double totalCalories = selectedFoods.stream().mapToDouble(Food::getCalories).sum();
        double calorieDifference = calories - totalCalories;
        double calorieFactor = calories / totalCalories;
        for (Food food : selectedFoods) {
            double adjustedQuantity = food.getGramosPorRacion() * calorieFactor;
            food.setGramos((int) adjustedQuantity);
        }

        return selectedFoods;
    }

    private List<Food> filterFoodsByType(String comida) {
        List<Food> filteredFoods = new ArrayList<>();
        for (Food food : foods) {
            if (food.getComida().equals(comida)) {
                filteredFoods.add(food);
            }
        }
        return filteredFoods;
    }

    private Food selectFood(List<Food> foodList) {
        Random random = new Random();
        return foodList.get(random.nextInt(foodList.size()));
    }
}
