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

    public static List<Carta> cartasTodas = new List<Carta>();

    private void Awake()
    {
        cartaAumentoList1.Clear();
        cartaAumentoList2.Clear();
        cartaClimaList1.Clear();
        cartaClimaList2.Clear();
        cartaOroList1.Clear();
        cartaOroList2.Clear();
        cartaPlataList1.Clear();
        cartaPlataList2.Clear();
        cartaSenueloList1.Clear();
        cartaSenueloList2.Clear();
        cartaFaccion1.Clear();
        cartaFaccion2.Clear();
        cartaDespejeList1.Clear();
        cartaDespejeList2.Clear();
        cartaLiderList1.Clear();
        cartaLiderList2.Clear();
        cartasTodas.Clear();

        //Aumento
        cartaAumentoList1.Add(new Carta(0,"Jessica",1,"R",0,0,2,0, "Aumento: Suma 2 al poder de cada carta de una fila.", Resources.Load<Sprite>("Cartas/Aumento/JESSICA")));
        cartaAumentoList2.Add(new Carta(1,"Jessica",2,"R",0,0,2, 0, "Aumento: Suma 2 al poder de cada carta de una fila.", Resources.Load<Sprite>("Cartas/Aumento/JESSICA")));
        cartaAumentoList1.Add(new Carta(2, "Beth Smith", 1,"M",0,0,2,0, "Aumento: Suma 2 al poder de cada carta de una fila.", Resources.Load<Sprite>("Cartas/Aumento/BETH")));
        cartaAumentoList1.Add(new Carta(3, "Jerry Smith", 1,"S",0,0,3,0, "Aumento: Suma 3 al poder de cada carta de una fila.", Resources.Load<Sprite>("Cartas/Aumento/JERRY")));
        cartaAumentoList2.Add(new Carta(4, "Mr. Goldenfold", 2,"M",0,0,2,0, "Aumento: Suma 2 al poder de cada carta de una fila.", Resources.Load<Sprite>("Cartas/Aumento/MR. GOLDENFOLD")));
        cartaAumentoList2.Add(new Carta(5, "Summer Smith", 2,"S",0,0,3,0, "Aumento: Suma 3 al poder de cada carta de una fila.", Resources.Load<Sprite>("Cartas/Aumento/SUMMER")));

        //Clima
        cartaClimaList1.Add(new Carta(6, "Furp Rock", 1, "S", 0, 1,4, 1, "Clima: Resta 4 al poder de cada carta de una fila.", Resources.Load<Sprite>("Cartas/Clima/FURP ROCK")));
        cartaClimaList2.Add(new Carta(7, "Furp Rock", 2, "S", 0, 1,4, 1, "Clima: Resta 4 al poder de cada carta de una fila.", Resources.Load<Sprite>("Cartas/Clima/FURP ROCK")));
        cartaClimaList1.Add(new Carta(8, "Galaxy", 1, "R", 0, 1,3, 1, "Clima: Resta 3 al poder de cada carta de una fila.", Resources.Load<Sprite>("Cartas/Clima/GALAXY")));
        cartaClimaList1.Add(new Carta(9, "Pluto", 1, "M", 0, 1,2, 1, "Clima: Resta 2 al poder de cada carta de una fila.", Resources.Load<Sprite>("Cartas/Clima/PLUTO")));
        cartaClimaList1.Add(new Carta(10, "Earth", 1, "S", 0, 1,1, 1, "Clima: Resta 1 al poder de cada carta de una fila.", Resources.Load<Sprite>("Cartas/Clima/EARTH")));
        cartaClimaList2.Add(new Carta(11, "Midland Quasar", 2, "R", 0, 1,3, 1, "Clima: Resta 3 al poder de cada carta de una fila.", Resources.Load<Sprite>("Cartas/Clima/MIDLAND QUASAR")));
        cartaClimaList2.Add(new Carta(12, "Gramuflack", 2, "M", 0, 1,2, 1, "Clima: Resta 2 al poder de cada carta de una fila.", Resources.Load<Sprite>("Cartas/Clima/GRAMUFLACK")));
        cartaClimaList2.Add(new Carta(13, "Snake Planet", 2, "S", 0, 1,1, 1, "Clima: Resta 1 al poder de cada carta de una fila.", Resources.Load<Sprite>("Cartas/Clima/SNAKE PLANET")));

        //Despeje
        cartaDespejeList1.Add(new Carta(14, "Ruben", 1, "R", 0, 2, 0, 2, "Despeje: Elimina Clima de una fila seleccionada propia y del rival.", Resources.Load<Sprite>("Cartas/Despeje/RUBEN")));
        cartaDespejeList2.Add(new Carta(15, "Ruben", 2, "R", 0, 2, 0, 2, "Despeje: Elimina Clima de una fila seleccionada propia y del rival.", Resources.Load<Sprite>("Cartas/Despeje/RUBEN")));
        cartaDespejeList1.Add(new Carta(16, "Hormigas en los ojos Johnson", 1, "M", 0, 2, 0, 2, "Despeje: Elimina Clima de una fila seleccionada propia y del rival.", Resources.Load<Sprite>("Cartas/Despeje/HORMIGAS EN LOS OJOS JOHNSON")));
        cartaDespejeList2.Add(new Carta(17, "Vendedor de puertas falsas reales", 2, "S", 0, 2, 0, 2, "Despeje: Elimina Clima de una fila seleccionada propia y del rival.", Resources.Load<Sprite>("Cartas/Despeje/VENDEDOR DE PUERTAS FALSAS REALES")));

        //Lider
        cartaLiderList1.Add(new Carta(18, "Rick Sanchez", 1, "", 0, 3, 0, 3, "Líder: Mantiene una carta aleatoria en el campo entre rondas.", Resources.Load<Sprite>("Cartas/Lider/RICK")));
        cartaLiderList2.Add(new Carta(19, "Morty Smith", 2, "", 0, 3, 0, 3, "Líder: Mantiene una carta aleatoria en el campo entre rondas.", Resources.Load<Sprite>("Cartas/lider/MORTY")));

        //Oro
        cartaOroList1.Add(new Carta(20,"Scary Terry",1,"M",4,4,0,4,"Oro: Elimina la carta con menos poder del rival.",Resources.Load<Sprite>("Cartas/Oro/SCARY TERRY")));
        cartaOroList1.Add(new Carta(21,"Hepatitis A",1, "R", 5,5,0,4,"Oro: Limpia la fila no vacía del rival con menos unidades.",Resources.Load<Sprite>("Cartas/Oro/HEPATITIS A")));
        cartaOroList1.Add(new Carta(22,"Squanchy",1, "S", 6,6,0,4,"Oro: Permite poner un clima.",Resources.Load<Sprite>("Cartas/Oro/SQUANCHY")));
        cartaOroList1.Add(new Carta(23, "Joyce Smith", 1, "M", 9,-1,0,4,"Oro",Resources.Load<Sprite>("Cartas/Oro/JOYCE SMITH")));
        cartaOroList2.Add(new Carta(24, "Abradolf Lincler", 2, "M", 4, 4, 0, 4, "Oro: Elimina la carta con menos poder del rival.", Resources.Load<Sprite>("Cartas/Oro/ABRADOLF LINCLER")));
        cartaOroList2.Add(new Carta(25, "Hepatitis C", 2, "R", 5, 5, 0, 4, "Oro: Limpia la fila no vacía del rival con menos unidades.", Resources.Load<Sprite>("Cartas/Oro/HEPATITIS C")));
        cartaOroList2.Add(new Carta(26, "Morty Smith Jr.", 2, "S", 6, 6, 0, 4, "Oro: Permite poner un clima.", Resources.Load<Sprite>("Cartas/Oro/MORTY SMITH JR.")));
        cartaOroList2.Add(new Carta(27, "Leonard Smith", 2, "M", 9, -1, 0, 4, "Oro", Resources.Load<Sprite>("Cartas/Oro/LEONARD SMITH")));

        //Plata
        cartaPlataList1.Add(new Carta(28, "Pickle Rick", 1, "M", 1, 7, 0, 5, "Plata: Permite robar una carta.", Resources.Load<Sprite>("Cartas/Plata/PICKLE RICK")));
        cartaPlataList1.Add(new Carta(29, "Pickle Rick", 1, "M", 1, 7, 0, 5, "Plata: Permite robar una carta.", Resources.Load<Sprite>("Cartas/Plata/PICKLE RICK")));
        cartaPlataList1.Add(new Carta(30, "Pickle Rick", 1, "M", 1, 7, 0, 5, "Plata: Permite robar una carta.", Resources.Load<Sprite>("Cartas/Plata/PICKLE RICK")));
        cartaPlataList1.Add(new Carta(31, "Birdperson", 1, "R", 2, 8, 0, 5, "Plata: Multiplica por N su ataque (N = la cantidad de cartas iguales a ella en el campo).", Resources.Load<Sprite>("Cartas/Plata/BIRDPERSON")));
        cartaPlataList1.Add(new Carta(32, "Birdperson", 1, "R", 2, 8, 0, 5, "Plata: Multiplica por N su ataque (N = la cantidad de cartas iguales a ella en el campo).", Resources.Load<Sprite>("Cartas/Plata/BIRDPERSON")));
        cartaPlataList1.Add(new Carta(33, "Birdperson", 1, "R", 2, 8, 0, 5, "Plata: Multiplica por N su ataque (N = la cantidad de cartas iguales a ella en el campo).", Resources.Load<Sprite>("Cartas/Plata/BIRDPERSON")));
        cartaPlataList1.Add(new Carta(34, "Mr. Meeseeks", 1, "S", 3, 9, 0, 5, "Plata: Permite poner un Aumento.", Resources.Load<Sprite>("Cartas/Plata/MR. MEESEEKS")));
        cartaPlataList1.Add(new Carta(35, "Mr. Meeseeks", 1, "S", 3, 9, 0, 5, "Plata: Permite poner un Aumento.", Resources.Load<Sprite>("Cartas/Plata/MR. MEESEEKS")));
        cartaPlataList1.Add(new Carta(36, "Mr. Meeseeks", 1, "S", 3, 9, 0, 5, "Plata: Permite poner un Aumento.", Resources.Load<Sprite>("Cartas/Plata/MR. MEESEEKS")));
        cartaPlataList2.Add(new Carta(37, "Mr. Poopybutthole", 2, "M", 1, 7, 0, 5, "Plata: Permite robar una carta.", Resources.Load<Sprite>("Cartas/Plata/MR. POOPYBUTTHOLE")));
        cartaPlataList2.Add(new Carta(38, "Mr. Poopybutthole", 2, "M", 1, 7, 0, 5, "Plata: Permite robar una carta.", Resources.Load<Sprite>("Cartas/Plata/MR. POOPYBUTTHOLE")));
        cartaPlataList2.Add(new Carta(39, "Mr. Poopybutthole", 2, "M", 1, 7, 0, 5, "Plata: Permite robar una carta.", Resources.Load<Sprite>("Cartas/Plata/MR. POOPYBUTTHOLE")));
        cartaPlataList2.Add(new Carta(40, "Dos Hermanos", 2, "R", 2, 8, 0, 5, "Plata: Multiplica por N su ataque (N = la cantidad de cartas iguales a ella en el campo).", Resources.Load<Sprite>("Cartas/Plata/DOS HERMANOS")));
        cartaPlataList2.Add(new Carta(41, "Dos Hermanos", 2, "R", 2, 8, 0, 5, "Plata: Multiplica por N su ataque (N = la cantidad de cartas iguales a ella en el campo).", Resources.Load<Sprite>("Cartas/Plata/DOS HERMANOS")));
        cartaPlataList2.Add(new Carta(42, "Dos Hermanos", 2, "R", 2, 8, 0, 5, "Plata: Multiplica por N su ataque (N = la cantidad de cartas iguales a ella en el campo).", Resources.Load<Sprite>("Cartas/Plata/DOS HERMANOS")));
        cartaPlataList2.Add(new Carta(43, "Snuffles (Snowball)", 2, "S", 3, 9, 0, 5, "Plata: Permite poner un Aumento.", Resources.Load<Sprite>("Cartas/Plata/SNOWBALLS")));
        cartaPlataList2.Add(new Carta(44, "Snuffles (Snowball)", 2, "S", 3, 9, 0, 5, "Plata: Permite poner un Aumento.", Resources.Load<Sprite>("Cartas/Plata/SNOWBALLS")));
        cartaPlataList2.Add(new Carta(45, "Snuffles (Snowball)", 2, "S", 3, 9, 0, 5, "Plata: Permite poner un Aumento.", Resources.Load<Sprite>("Cartas/Plata/SNOWBALLS")));

        //Senuelo
        cartaSenueloList1.Add(new Carta(46, "Jacob Philip", 1, "M", 0, 10, 0, 6, "Señuelo: Se intercambia por una carta propia del campo.", Resources.Load<Sprite>("Cartas/Señuelo/JACOB PHILIP")));
        cartaSenueloList2.Add(new Carta(47,"Jacob Philip", 2, "M", 0, 10, 0, 6, "Señuelo: Se intercambia por una carta propia del campo.", Resources.Load<Sprite>("Cartas/Señuelo/JACOB PHILIP")));
        cartaSenueloList1.Add(new Carta(48, "Gwendolyn", 1, "R", 0, 10, 0, 6, "Señuelo: Se intercambia por una carta propia del campo.", Resources.Load<Sprite>("Cartas/Señuelo/GWENDOLYN")));
        cartaSenueloList2.Add(new Carta(49, "Rey Frijol", 2, "S", 0, 10, 0, 6, "Señuelo: Se intercambia por una carta propia del campo.", Resources.Load<Sprite>("Cartas/Señuelo/REY FRIJOL")));

        //Facciones
        cartaFaccion1 = Enumerable.Concat(cartaFaccion1,cartaAumentoList1).ToList();
        cartaFaccion1 = Enumerable.Concat(cartaFaccion1,cartaClimaList1).ToList();
        cartaFaccion1 = Enumerable.Concat(cartaFaccion1,cartaDespejeList1).ToList();
        cartaFaccion1 = Enumerable.Concat(cartaFaccion1,cartaLiderList1).ToList();
        cartaFaccion1 = Enumerable.Concat(cartaFaccion1,cartaOroList1).ToList();
        cartaFaccion1 = Enumerable.Concat(cartaFaccion1,cartaPlataList1).ToList();
        cartaFaccion1 = Enumerable.Concat(cartaFaccion1,cartaSenueloList1).ToList();
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
