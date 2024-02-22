package es.uniovi.miw.ws.miwfit.foodapi.model;

import java.io.Serializable;
public class Food implements Serializable{

    private static final long serialVersionUID = 1L;
    private String name;
    private String flickrname;
    private double calories;
    private String comida;
    private double proteina;
    private double grasas;
    private double azucares;

    public double getGramosPorRacion() {
        return gramosPorRacion;
    }

    public void setGramosPorRacion(double gramosPorRacion) {
        this.gramosPorRacion = gramosPorRacion;
    }

    public double getGramos() {
        return gramos;
    }

    public void setGramos(double gramos) {
        this.gramos = gramos;
    }

    private double gramosPorRacion;
    private double gramos;

    public Food(){}

    public Food(String name, String flickrname, double calories, String comida, double proteina, double grasas, double azucares, double gramosPorRacion) {
        this.name = name;
        this.calories = calories;
        this.flickrname = flickrname;
        this.comida = comida;
        this.proteina = proteina;
        this.grasas = grasas;
        this.azucares = azucares;
        this.gramosPorRacion = gramosPorRacion;
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

    public String getComida() {
        return comida;
    }

    public void setComida(String comida) {
        this.comida = comida;
    }

    public double getProteina() {
        return proteina;
    }

    public void setProteina(double proteina) {
        this.proteina = proteina;
    }

    public double getGrasas() {
        return grasas;
    }

    public void setGrasas(double grasas) {
        this.grasas = grasas;
    }

    public double getAzucares() {
        return azucares;
    }

    public void setAzucares(double azucares) {
        this.azucares = azucares;
    }

    public String getFlickrname() {
        return flickrname;
    }

    public void setFlickrname(String flickrname) {
        this.flickrname = flickrname;
    }
}
