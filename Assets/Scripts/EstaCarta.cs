using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class EstaCarta : MonoBehaviour
{
    //Mostrar carta
    public List<Carta> estaCarta = new List<Carta>();
    public int esteId;

    public int id;
    public string nombre;
    public int faccion;
    public string filas;
    public int poder;
    public int efectosId;
    public int ataque;
    public int tipoId;
    public string descripcion;
    public Sprite spriteImagen;

    public TMP_Text nombreText;
    public TMP_Text faccionText;
    public TMP_Text filasText;
    public TMP_Text poderText;
    public TMP_Text descripcionText;
    public Image imagenSprite;

    public bool dorsoCarta;
    public static bool staticDorsoCarta;

    // Start is called before the first frame update
    void Start()
    {
        estaCarta[0] = BDCartas.cartasTodas[esteId];    
    }

    // Update is called once per frame
    void Update()
    {
        id = estaCarta[0].id;
        nombre = estaCarta[0].nombre;
        faccion = estaCarta[0].faccion;
        filas = estaCarta[0].filas;
        poder = estaCarta[0].poder;
        efectosId = estaCarta[0].efectosId;
        ataque = estaCarta[0].ataque;
        tipoId = estaCarta[0].tipoId;
        descripcion = estaCarta[0].descripcion;
        spriteImagen = estaCarta[0].spriteImagen;

        nombreText.text = "" + nombre;
        faccionText.text = "" + faccion;
        filasText.text = "" + filas;
        poderText.text = "" + poder;
        descripcionText.text = "" + descripcion;
        imagenSprite.sprite = spriteImagen;

        staticDorsoCarta = dorsoCarta;
    }
}
