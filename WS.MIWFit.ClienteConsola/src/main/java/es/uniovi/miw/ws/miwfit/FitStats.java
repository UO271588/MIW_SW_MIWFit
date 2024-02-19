package es.uniovi.miw.ws.miwfit;

import java.io.Serializable;
import java.util.Date;

public class FitStats implements Serializable {
    private static final long serialVersionUID = 1L;

    private int id;
    private double weight;
    private double height;
    private double imc;
    private double calories;
    private double superavit;
    private double deficit;
    private String activity = "";
    private Date date;
    private User user = new User();

    public FitStats(){}


    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public double getWeight() {
        return weight;
    }

    public void setWeight(double weight) {
        this.weight = weight;
    }

    public double getHeight() {
        return height;
    }

    public void setHeight(double height) {
        this.height = height;
    }

    public double getImc() {
        return imc;
    }

    public void setImc(double imc) {
        this.imc = imc;
    }

    public double getCalories() {
        return calories;
    }

    public void setCalories(double calories) {
        this.calories = calories;
    }

    public double getSuperavit() {
        return superavit;
    }

    public void setSuperavit(double superavit) {
        this.superavit = superavit;
    }

    public double getDeficit() {
        return deficit;
    }

    public void setDeficit(double deficit) {
        this.deficit = deficit;
    }

    public String getActivity() {
        return activity;
    }

    public void setActivity(String activity) {
        this.activity = activity;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }
}
