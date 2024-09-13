using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private bool inicializado = false;
    public void PlayGame()
    {
        if (!inicializado)
        {
            BDCartas.Inicializar();
            inicializado = true;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CrearCarta()
    {
        if (!inicializado)
        {
            BDCartas.Inicializar();
            inicializado = true;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
