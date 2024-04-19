using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntos : MonoBehaviour
{
    public int puntos1;
    public int puntos2;

    public TMP_Text textPuntos1;
    public TMP_Text textPuntos2;

    // Start is called before the first frame update
    void Start()
    {
        puntos1 = 0;
        puntos2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textPuntos1.text = "" + puntos1; 
        textPuntos2.text = "" + puntos2;
    }
}
