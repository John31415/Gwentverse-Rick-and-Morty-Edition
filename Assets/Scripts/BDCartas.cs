using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BDCartas : MonoBehaviour
{
    public static List<Carta> cartaAumentoList1 = new List<Carta>();
    public static List<Carta> cartaAumentoList2 = new List<Carta>();

    public static List<Carta> cartaClimaList1 = new List<Carta>();
    public static List<Carta> cartaClimaList2 = new List<Carta>();

    public static List<Carta> cartaDespejeList1 = new List<Carta>();
    public static List<Carta> cartaDespejeList2 = new List<Carta>();

    public static List<Carta> cartaLiderList1 = new List<Carta>();
    public static List<Carta> cartaLiderList2 = new List<Carta>();

    public static List<Carta> cartaOroList1 = new List<Carta>();
    public static List<Carta> cartaOroList2 = new List<Carta>();

    public static List<Carta> cartaPlataList1 = new List<Carta>();
    public static List<Carta> cartaPlataList2 = new List<Carta>();

    public static List<Carta> cartaSenueloList1 = new List<Carta>();
    public static List<Carta> cartaSenueloList2 = new List<Carta>();

    public static List<Carta> cartaFaccion1 = new List<Carta>();
    public static List<Carta> cartaFaccion2 = new List<Carta>();

    public static List<Carta> cartaOdin1 = new List<Carta>();
    public static List<Carta> cartaOdin2 = new List<Carta>();

    public static List<Carta> cartasTodas = new List<Carta>();

    public static Dictionary<string, string> sprites = new Dictionary<string, string>();

    private static bool band = false;

    public static void Inicializar()
    {
        if (band == true)
        {
            return;
        }
        band = true;

        //Sprites
        sprites["Jessica"] = "Cartas/Aumento/JESSICA";
        sprites["Beth Smith"] = "Cartas/Aumento/BETH";
        sprites["Jerry Smith"] = "Cartas/Aumento/JERRY";
        sprites["Mr. Goldenfold"] = "Cartas/Aumento/MR. GOLDENFOLD";
        sprites["Summer Smith"] = "Cartas/Aumento/SUMMER";
        sprites["Furp Rock"] = "Cartas/Clima/FURP ROCK";
        sprites["Galaxy"] = "Cartas/Clima/GALAXY";
        sprites["Pluto"] = "Cartas/Clima/PLUTO";
        sprites["Earth"] = "Cartas/Clima/EARTH";
        sprites["Midland Quasar"] = "Cartas/Clima/MIDLAND QUASAR";
        sprites["Gramuflack"] = "Cartas/Clima/GRAMUFLACK";
        sprites["Snake Planet"] = "Cartas/Clima/SNAKE PLANET";
        sprites["Ruben"] = "Cartas/Despeje/RUBEN";
        sprites["Hormigas en los ojos Johnson"] = "Cartas/Despeje/HORMIGAS EN LOS OJOS JOHNSON";
        sprites["Vendedor de puertas falsas reales"] = "Cartas/Despeje/VENDEDOR DE PUERTAS FALSAS REALES";
        sprites["Rick Sanchez"] = "Cartas/Lider/RICK";
        sprites["Morty Smith"] = "Cartas/lider/MORTY";
        sprites["Scary Terry"] = "Cartas/Oro/SCARY TERRY";
        sprites["Hepatitis A"] = "Cartas/Oro/HEPATITIS A";
        sprites["Squanchy"] = "Cartas/Oro/SQUANCHY";
        sprites["Joyce Smith"] = "Cartas/Oro/JOYCE SMITH";
        sprites["Abradolf Lincler"] = "Cartas/Oro/ABRADOLF LINCLER";
        sprites["Hepatitis C"] = "Cartas/Oro/HEPATITIS C";
        sprites["Morty Smith Jr."] = "Cartas/Oro/MORTY SMITH JR.";
        sprites["Leonard Smith"] = "Cartas/Oro/LEONARD SMITH";
        sprites["Pickle Rick"] = "Cartas/Plata/PICKLE RICK";
        sprites["Birdperson"] = "Cartas/Plata/BIRDPERSON";
        sprites["Mr. Meeseeks"] = "Cartas/Plata/MR. MEESEEKS";
        sprites["Mr. Poopybutthole"] = "Cartas/Plata/MR. POOPYBUTTHOLE";
        sprites["Dos Hermanos"] = "Cartas/Plata/DOS HERMANOS";
        sprites["Snuffles (Snowball)"] = "Cartas/Plata/SNOWBALLS";
        sprites["Jacob Philip"] = "Cartas/Señuelo/JACOB PHILIP";
        sprites["Gwendolyn"] = "Cartas/Señuelo/GWENDOLYN";
        sprites["Rey Frijol"] = "Cartas/Señuelo/REY FRIJOL";
        sprites["Odin"] = "Cartas/Odin/ODIN";

        //Aumento
        cartaAumentoList1.Add(new Carta(0, "Jessica", 1, "R", 0, 0, 2, 0, "Aumenta en 2 el poder de cada carta de su fila(R).", Resources.Load<Sprite>(sprites["Jessica"])));
        cartaAumentoList2.Add(new Carta(1, "Jessica", 2, "R", 0, 0, 2, 0, "Aumenta en 2 el poder de cada carta de su fila(R).", Resources.Load<Sprite>(sprites["Jessica"])));
        cartaAumentoList1.Add(new Carta(2, "Beth Smith", 1, "M", 0, 0, 2, 0, "Aumenta en 2 el poder de cada carta de su fila(M).", Resources.Load<Sprite>(sprites["Beth Smith"])));
        cartaAumentoList1.Add(new Carta(3, "Jerry Smith", 1, "S", 0, 0, 3, 0, "Aumenta en 3 el poder de cada carta de su fila(S).", Resources.Load<Sprite>(sprites["Jerry Smith"])));
        cartaAumentoList2.Add(new Carta(4, "Mr. Goldenfold", 2, "M", 0, 0, 2, 0, "Aumenta en 2 el poder de cada carta de su fila(M).", Resources.Load<Sprite>(sprites["Mr. Goldenfold"])));
        cartaAumentoList2.Add(new Carta(5, "Summer Smith", 2, "S", 0, 0, 3, 0, "Aumenta en 3 el poder de cada carta de su fila(S).", Resources.Load<Sprite>(sprites["Summer Smith"])));
        
        //Clima
        cartaClimaList1.Add(new Carta(6, "Furp Rock", 1, "S", 0, 1, 4, 1, "Resta 4 al poder de cada carta en su fila.", Resources.Load<Sprite>(sprites["Furp Rock"])));
        cartaClimaList2.Add(new Carta(7, "Furp Rock", 2, "S", 0, 1, 4, 1, "Resta 4 al poder de cada carta en su fila.", Resources.Load<Sprite>(sprites["Furp Rock"])));
        cartaClimaList1.Add(new Carta(8, "Galaxy", 1, "R", 0, 1, 3, 1, "Resta 3 al poder de cada carta en su fila.", Resources.Load<Sprite>(sprites["Galaxy"])));
        cartaClimaList1.Add(new Carta(9, "Pluto", 1, "M", 0, 1, 2, 1, "Resta 2 al poder de cada carta en su fila.", Resources.Load<Sprite>(sprites["Pluto"])));
        cartaClimaList1.Add(new Carta(10, "Earth", 1, "S", 0, 1, 1, 1, "Resta 1 al poder de cada carta en su fila.", Resources.Load<Sprite>(sprites["Earth"])));
        cartaClimaList2.Add(new Carta(11, "Midland Quasar", 2, "R", 0, 1, 3, 1, "Resta 3 al poder de cada carta en su fila.", Resources.Load<Sprite>(sprites["Midland Quasar"])));
        cartaClimaList2.Add(new Carta(12, "Gramuflack", 2, "M", 0, 1, 2, 1, "Resta 2 al poder de cada carta en su fila.", Resources.Load<Sprite>(sprites["Gramuflack"])));
        cartaClimaList2.Add(new Carta(13, "Snake Planet", 2, "S", 0, 1, 1, 1, "Resta 1 al poder de cada carta en su fila.", Resources.Load<Sprite>(sprites["Snake Planet"])));
        
        //Despeje
        cartaDespejeList1.Add(new Carta(14, "Ruben", 1, "R", 0, 2, 0, 2, "Despeja Clima de la fila(R) del campo enemigo.", Resources.Load<Sprite>(sprites["Ruben"])));
        cartaDespejeList2.Add(new Carta(15, "Ruben", 2, "R", 0, 2, 0, 2, "Despeja Clima de la fila(R) del campo enemigo.", Resources.Load<Sprite>(sprites["Ruben"])));
        cartaDespejeList1.Add(new Carta(16, "Hormigas en los ojos Johnson", 1, "M", 0, 2, 0, 2, "Despeja Clima de la fila(M) del campo enemigo.", Resources.Load<Sprite>(sprites["Hormigas en los ojos Johnson"])));
        cartaDespejeList2.Add(new Carta(17, "Vendedor de puertas falsas reales", 2, "S", 0, 2, 0, 2, "Despeja Clima de la fila(S) del campo enemigo.", Resources.Load<Sprite>(sprites["Vendedor de puertas falsas reales"])));
        
        //Lider
        cartaLiderList1.Add(new Carta(18, "Rick Sanchez", 1, "", 0, 3, 0, 3, "Permite robar una carta entre las rondas 2 y 3.", Resources.Load<Sprite>(sprites["Rick Sanchez"])));
        cartaLiderList2.Add(new Carta(19, "Morty Smith", 2, "", 0, 3, 0, 3, "Permite robar una carta entre las rondas 2 y 3.", Resources.Load<Sprite>(sprites["Morty Smith"])));
        
        //Oro
        cartaOroList1.Add(new Carta(20, "Scary Terry", 1, "M", 4, 4, 0, 4, "Aniquila la carta enemiga menos poderosa.", Resources.Load<Sprite>(sprites["Scary Terry"])));
        cartaOroList1.Add(new Carta(21, "Hepatitis A", 1, "R", 5, 5, 0, 4, "Aniquila las unidades Plata de la fila no vacía del rival con menos cartas.", Resources.Load<Sprite>(sprites["Hepatitis A"])));
        cartaOroList1.Add(new Carta(22, "Squanchy", 1, "S", 6, 6, 0, 4, "Activa un Clima al azar desde la mano.", Resources.Load<Sprite>(sprites["Squanchy"])));
        cartaOroList1.Add(new Carta(23, "Joyce Smith", 1, "M", 9, -1, 0, 4, "", Resources.Load<Sprite>(sprites["Joyce Smith"])));
        cartaOroList2.Add(new Carta(24, "Abradolf Lincler", 2, "M", 4, 4, 0, 4, "Aniquila la carta enemiga menos poderosa.", Resources.Load<Sprite>(sprites["Abradolf Lincler"])));
        cartaOroList2.Add(new Carta(25, "Hepatitis C", 2, "R", 5, 5, 0, 4, "Aniquila las unidades Plata de la fila no vacía del rival con menos cartas.", Resources.Load<Sprite>(sprites["Hepatitis C"])));
        cartaOroList2.Add(new Carta(26, "Morty Smith Jr.", 2, "S", 6, 6, 0, 4, "Activa un Clima al azar desde la mano.", Resources.Load<Sprite>(sprites["Morty Smith Jr."])));
        cartaOroList2.Add(new Carta(27, "Leonard Smith", 2, "M", 9, -1, 0, 4, "", Resources.Load<Sprite>(sprites["Leonard Smith"])));
        
        //Plata
        cartaPlataList1.Add(new Carta(28, "Pickle Rick", 1, "M", 1, 7, 0, 5, "Roba una carta del mazo.", Resources.Load<Sprite>(sprites["Pickle Rick"])));
        cartaPlataList1.Add(new Carta(29, "Pickle Rick", 1, "M", 1, 7, 0, 5, "Roba una carta del mazo.", Resources.Load<Sprite>(sprites["Pickle Rick"])));
        cartaPlataList1.Add(new Carta(30, "Pickle Rick", 1, "M", 1, 7, 0, 5, "Roba una carta del mazo.", Resources.Load<Sprite>(sprites["Pickle Rick"])));
        cartaPlataList1.Add(new Carta(31, "Birdperson", 1, "R", 2, 8, 0, 5, "Su poder se multiplica por la cantidad de cartas iguales a ella en el campo.", Resources.Load<Sprite>(sprites["Birdperson"])));
        cartaPlataList1.Add(new Carta(32, "Birdperson", 1, "R", 2, 8, 0, 5, "Su poder se multiplica por la cantidad de cartas iguales a ella en el campo.", Resources.Load<Sprite>(sprites["Birdperson"])));
        cartaPlataList1.Add(new Carta(33, "Birdperson", 1, "R", 2, 8, 0, 5, "Su poder se multiplica por la cantidad de cartas iguales a ella en el campo.", Resources.Load<Sprite>(sprites["Birdperson"])));
        cartaPlataList1.Add(new Carta(34, "Mr. Meeseeks", 1, "S", 3, 9, 0, 5, "Activa un Aumento al azar desde la mano.", Resources.Load<Sprite>(sprites["Mr. Meeseeks"])));
        cartaPlataList1.Add(new Carta(35, "Mr. Meeseeks", 1, "S", 3, 9, 0, 5, "Activa un Aumento al azar desde la mano.", Resources.Load<Sprite>(sprites["Mr. Meeseeks"])));
        cartaPlataList1.Add(new Carta(36, "Mr. Meeseeks", 1, "S", 3, 9, 0, 5, "Activa un Aumento al azar desde la mano.", Resources.Load<Sprite>(sprites["Mr. Meeseeks"])));
        cartaPlataList2.Add(new Carta(37, "Mr. Poopybutthole", 2, "M", 1, 7, 0, 5, "Roba una carta del mazo.", Resources.Load<Sprite>(sprites["Mr. Poopybutthole"])));
        cartaPlataList2.Add(new Carta(38, "Mr. Poopybutthole", 2, "M", 1, 7, 0, 5, "Roba una carta del mazo.", Resources.Load<Sprite>(sprites["Mr. Poopybutthole"])));
        cartaPlataList2.Add(new Carta(39, "Mr. Poopybutthole", 2, "M", 1, 7, 0, 5, "Roba una carta del mazo.", Resources.Load<Sprite>(sprites["Mr. Poopybutthole"])));
        cartaPlataList2.Add(new Carta(40, "Dos Hermanos", 2, "R", 2, 8, 0, 5, "Su poder se multiplica por la cantidad de cartas iguales a ella en el campo.", Resources.Load<Sprite>(sprites["Dos Hermanos"])));
        cartaPlataList2.Add(new Carta(41, "Dos Hermanos", 2, "R", 2, 8, 0, 5, "Su poder se multiplica por la cantidad de cartas iguales a ella en el campo.", Resources.Load<Sprite>(sprites["Dos Hermanos"])));
        cartaPlataList2.Add(new Carta(42, "Dos Hermanos", 2, "R", 2, 8, 0, 5, "Su poder se multiplica por la cantidad de cartas iguales a ella en el campo.", Resources.Load<Sprite>(sprites["Dos Hermanos"])));
        cartaPlataList2.Add(new Carta(43, "Snuffles (Snowball)", 2, "S", 3, 9, 0, 5, "Activa un Aumento al azar desde la mano.", Resources.Load<Sprite>(sprites["Snuffles (Snowball)"])));
        cartaPlataList2.Add(new Carta(44, "Snuffles (Snowball)", 2, "S", 3, 9, 0, 5, "Activa un Aumento al azar desde la mano.", Resources.Load<Sprite>(sprites["Snuffles (Snowball)"])));
        cartaPlataList2.Add(new Carta(45, "Snuffles (Snowball)", 2, "S", 3, 9, 0, 5, "Activa un Aumento al azar desde la mano.", Resources.Load<Sprite>(sprites["Snuffles (Snowball)"])));
        
        //Senuelo
        cartaSenueloList1.Add(new Carta(46, "Jacob Philip", 1, "M", 0, 10, 0, 6, "Se intercambia por una carta de unidad propia a seleccionar.", Resources.Load<Sprite>(sprites["Jacob Philip"])));
        cartaSenueloList2.Add(new Carta(47, "Jacob Philip", 2, "M", 0, 10, 0, 6, "Se intercambia por una carta de unidad propia a seleccionar.", Resources.Load<Sprite>(sprites["Jacob Philip"])));
        cartaSenueloList1.Add(new Carta(48, "Gwendolyn", 1, "R", 0, 10, 0, 6, "Se intercambia por una carta de unidad propia a seleccionar.", Resources.Load<Sprite>(sprites["Gwendolyn"])));
        cartaSenueloList2.Add(new Carta(49, "Rey Frijol", 2, "S", 0, 10, 0, 6, "Se intercambia por una carta de unidad propia a seleccionar.", Resources.Load<Sprite>(sprites["Rey Frijol"])));

        //Facciones
        cartaFaccion1 = Enumerable.Concat(cartaFaccion1, cartaAumentoList1).ToList();
        cartaFaccion1 = Enumerable.Concat(cartaFaccion1, cartaClimaList1).ToList();
        cartaFaccion1 = Enumerable.Concat(cartaFaccion1, cartaDespejeList1).ToList();
        cartaFaccion1 = Enumerable.Concat(cartaFaccion1, cartaLiderList1).ToList();
        cartaFaccion1 = Enumerable.Concat(cartaFaccion1, cartaOroList1).ToList();
        cartaFaccion1 = Enumerable.Concat(cartaFaccion1, cartaPlataList1).ToList();
        cartaFaccion1 = Enumerable.Concat(cartaFaccion1, cartaSenueloList1).ToList();
        cartaFaccion2 = Enumerable.Concat(cartaFaccion2, cartaAumentoList2).ToList();
        cartaFaccion2 = Enumerable.Concat(cartaFaccion2, cartaClimaList2).ToList();
        cartaFaccion2 = Enumerable.Concat(cartaFaccion2, cartaDespejeList2).ToList();
        cartaFaccion2 = Enumerable.Concat(cartaFaccion2, cartaLiderList2).ToList();
        cartaFaccion2 = Enumerable.Concat(cartaFaccion2, cartaOroList2).ToList();
        cartaFaccion2 = Enumerable.Concat(cartaFaccion2, cartaPlataList2).ToList();
        cartaFaccion2 = Enumerable.Concat(cartaFaccion2, cartaSenueloList2).ToList();

        //Todas
        cartasTodas = Enumerable.Concat(cartaFaccion1, cartaFaccion2).ToList();
    }
}
