package es.uniovi.miw.ws.miwfit.foodapi.model;

import java.io.Serializable;
public class Food implements Serializable{

    private static final long serialVersionUID = 1L;

    private String name;

    private double calories;




    public Food(){}

    public Food(String name, double calories) {
        this.name = name;
        this.calories = calories;
    }

    public String getName(){
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public double getCalories(){
        return calories;
    }

    public void setCalories(double calories){
        this.calories = calories;
    }

}
