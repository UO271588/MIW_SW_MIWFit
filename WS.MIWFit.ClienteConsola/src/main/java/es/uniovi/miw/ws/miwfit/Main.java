package es.uniovi.miw.ws.miwfit;

import jakarta.ws.rs.client.ClientBuilder;
import jakarta.ws.rs.client.Entity;
import jakarta.ws.rs.core.GenericType;
import jakarta.ws.rs.core.MediaType;
import jakarta.ws.rs.core.Response;


import java.text.SimpleDateFormat;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        boolean loggedIn = false;
        String username = null;
        String token = null;
        Scanner scanner = new Scanner(System.in);

        while (true) {
            if (!loggedIn) {
                System.out.println("Por favor, inicia sesión:");
                System.out.print("Usuario: ");
                username = scanner.nextLine();
                System.out.print("Contraseña: ");
                String password = scanner.nextLine();
                User user = new User();
                user.setUsername(username);
                user.setPassword(password);
                Response response = ClientBuilder.newClient().
                        target("http://localhost:9081/api").
                        path("login").
                        request(MediaType.APPLICATION_JSON).
                        post(Entity.entity(user, MediaType.APPLICATION_JSON));
                try {
                    Token tokenObj = (Token) response.readEntity(Token.class);
                    loggedIn = true;
                    token = tokenObj.getToken();
                    System.out.println("Inicio de sesión exitoso.\n");
                }catch (Exception e){
                    System.out.println("Usuario o contraseña incorrectos. Inténtalo de nuevo.\n");
                }
            } else {
                System.out.println("Menú:");
                System.out.println("1. Calcular IMC");
                System.out.println("2. Obtener histórico");
                System.out.println("3. Cerrar sesión");
                System.out.print("Seleccione una opción (1|2|3): ");
                String opcion = scanner.nextLine();

                switch (opcion) {
                    case "1":
                        System.out.print("Introduzca los datos separados por comas: [peso],[altura (en cm)],[sexo (Hombre/Mujer),[actividad (Sedentario/Ligero/Moderado/Activo/Muy activo)]:");
                        String datos = scanner.nextLine();
                        String[] partes = datos.split(",");
                        if(partes.length == 4){
                            try{
                                double peso = Double.parseDouble(partes[0]);
                                double altura = Double.parseDouble(partes[1]);
                                String sexo = partes[2];
                                String actividad = partes[3];
                                if(peso > 0 && altura > 0 && (sexo.equals("Hombre") || sexo.equals("Mujer")) && !actividad.isEmpty()){
                                    DatosIMC datosIMC = new DatosIMC();
                                    datosIMC.setUsername(username);
                                    datosIMC.setPeso(peso);
                                    datosIMC.setAltura(altura);
                                    datosIMC.setSexo(sexo);
                                    datosIMC.setActividad(actividad);
                                    Response response = ClientBuilder.newClient().
                                            target("http://localhost:9081/api").
                                            path("fitStats").
                                            request(MediaType.APPLICATION_JSON).
                                            header("token",token).
                                            post(Entity.entity(datosIMC, MediaType.APPLICATION_JSON));
                                    System.out.println(response.readEntity(String.class));
                                    break;
                                }
                            }catch (Exception e){}
                        }
                        System.out.println("Opción inválida. Por favor, seleccione una opción válida.\n");
                        break;
                    case "2":
                        Response response = ClientBuilder.newClient().
                                target("http://localhost:9081/api").
                                path("fitStats/"+username).
                                request(MediaType.APPLICATION_JSON).
                                header("token",token).
                                get();
                        List<FitStats> fitStatsList = response.readEntity(new GenericType<List<FitStats>>() {});
                        System.out.println("Peso\tAltura\tIMC\tCalorias\tSuperavit\tDeficit\tFecha");
                        System.out.println("--------------------------------------------------------");
                        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");

                        for (FitStats fitStats : fitStatsList) {
                            String weight = Double.toString(fitStats.getWeight());
                            String height = Double.toString(fitStats.getHeight());
                            String imc = Double.toString(fitStats.getImc());
                            String calories = Double.toString(fitStats.getCalories());
                            String superavit = Double.toString(fitStats.getSuperavit());
                            String deficit = Double.toString(fitStats.getDeficit());
                            String date = dateFormat.format(fitStats.getDate());

                            String formattedString = String.format("%s\t%s\t%s\t%s\t%s\t%s\t%s", weight, height, imc, calories, superavit, deficit,date);
                            System.out.println(formattedString);
                        }
                        break;
                    case "3":
                        loggedIn = false;
                        System.out.println("Sesión cerrada.\n");
                        break;
                    default:
                        System.out.println("Opción inválida. Por favor, seleccione una opción válida.\n");
                        break;
                }
            }
        }
    }
}