package es.uniovi.miw.ws.miwfit;

import java.io.Serializable;

public class DatosIMC implements Serializable {
    private static final long serialVersionUID = 1L;

    private String username;
    private double peso;
    private double altura;
    private String sexo;
    private String actividad;

    public DatosIMC(){}

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
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

}
