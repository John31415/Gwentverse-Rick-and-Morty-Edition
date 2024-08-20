using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RecibirInput : MonoBehaviour
{
    public TMP_InputField inputField;

    public void RecibirTexto()
    {
        string userInput = inputField.text;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
