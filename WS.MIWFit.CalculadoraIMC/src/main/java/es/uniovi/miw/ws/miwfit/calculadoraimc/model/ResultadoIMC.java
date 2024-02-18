package es.uniovi.miw.ws.miwfit.calculadoraimc.model;

import java.io.Serializable;

public class ResultadoIMC implements Serializable {
    private static final long serialVersionUID = 1L;

    private double peso;
    private double altura;
    private String sexo;
    private String actividad;
    private double imc;
    private double pesoIdeal;
    private double calorias;
    private double superavit;
    private double deficit;

    public ResultadoIMC(){}
    public ResultadoIMC(double peso, double altura, String sexo, String actividad, double imc, double pesoIdeal, double calorias, double superavit, double deficit) {
        this.peso = peso;
        this.altura = altura;
        this.sexo = sexo;
        this.actividad = actividad;
        this.imc = imc;
        this.pesoIdeal = pesoIdeal;
        this.calorias = calorias;
        this.superavit = superavit;
        this.deficit = deficit;
    }

    public double getPeso() {
        return peso;
    }

    public void setPeso(double peso) {
        this.peso = peso;
    }

    public double getAltura() {
        return altura;
    }

    public void setAltura(double altura) {
        this.altura = altura;
    }

    public String getSexo() {
        return sexo;
    }

    public void setSexo(String sexo) {
        this.sexo = sexo;
    }

    public String getActividad() {
        return actividad;
    }

    public void setActividad(String actividad) {
        this.actividad = actividad;
    }

    public double getImc() {
        return imc;
    }

    public void setImc(double imc) {
        this.imc = imc;
    }

    public double getPesoIdeal() {
        return pesoIdeal;
    }

    public void setPesoIdeal(double pesoIdeal) {
        this.pesoIdeal = pesoIdeal;
    }

    public double getCalorias() {
        return calorias;
    }

    public void setCalorias(double calorias) {
        this.calorias = calorias;
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

    public String getErrorMessage(){
        String message = "InvalidDataException - These Arguments are invalid:[";
        if(getPeso() <= 0)
            message += " peso ";
        if(getAltura() <= 0)
            message += " altura ";
        if(getSexo() == null || getSexo().isBlank() || getSexo().isEmpty())
            message += " sexo ";
        if(getActividad() == null || getActividad().isBlank() || getActividad().isEmpty())
            message += " actividad ";
        return message + "]";
    }
}
