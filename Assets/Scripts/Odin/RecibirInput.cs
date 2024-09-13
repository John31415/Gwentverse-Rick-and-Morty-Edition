using Odin;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RecibirInput : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text errors;

    public static string UserInput;

    public void RecibirTexto()
    {
        EventSystem.current.SetSelectedGameObject(null);
        if(inputField.text == null || inputField.text == "")
        {
            errors.text = "There is no code at all. You must type something.";
            return;
        }
        string userInput = "";
        foreach(var card in BDCartas.cartaOdin1)
        {
            BDCartas.cartasTodas.Remove(card);
        }
        BDCartas.cartaOdin1.Clear();
        foreach (var card in BDCartas.cartaOdin2)
        {
            BDCartas.cartasTodas.Remove(card);
        }
        BDCartas.cartaOdin2.Clear();
        userInput = inputField.text;
        userInput += "\n";
        Run.RunCode(userInput);
        if (!(Run.Errors == ""))
        {
            errors.text = "\"" + ErrorPhrases.RandErrorPhrase() + "\"\n\n" + Run.Errors + "\nThe build failed. Fix the build errors and run again.";
            return;
        }
        UserInput = userInput;
        CardCreator cardCreator = new CardCreator(Run.CardsCreated);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}