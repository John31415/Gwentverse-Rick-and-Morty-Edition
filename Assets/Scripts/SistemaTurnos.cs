using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaTurnos : MonoBehaviour
{
    public static int turno;
    public GameObject panel1;
    public GameObject panel2;

    // Start is called before the first frame update
    void Start()
    {
        turno = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Controlador.jugadorActivo1 && !Controlador.jugadorActivo2)
        {
            turno = 1;
        }
        else if (!Controlador.jugadorActivo1 && Controlador.jugadorActivo2)
        {
            turno = 2;
        }
        else if (!Controlador.jugadorActivo1 && !Controlador.jugadorActivo2)
        {
            panel1.SetActive(true);
            panel2.SetActive(true);
            return;
        }
        if (turno == 1)
        {
            panel1.SetActive(false);
            panel2.SetActive(true);
        }
        else
        {
            panel2.SetActive(false);
            panel1.SetActive(true);
        }
    }

    public void CambioTurno()
    {
        if (turno == 1) Controlador.jugadorActivo1 = false;
        else Controlador.jugadorActivo2 = false;
        turno = turno % 2 + 1;
    }
}
