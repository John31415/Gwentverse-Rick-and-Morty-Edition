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

    public void RecibirTexto()
    {
        EventSystem.current.SetSelectedGameObject(null);
        if(inputField.text == null || inputField.text == "")
        {
            errors.text = "There is no code at all. You must type something.";
            return;
        }
        string userInput = "";
        userInput += inputField.text;
        userInput += "\n";
        Run run = new Run(null, userInput);
        if (!(Run.Errors == ""))
        {
            errors.text = "\"" + ErrorPhrases.RandErrorPhrase() + "\"\n\n" + Run.Errors + "\nThe build failed. Fix the build errors and run again.";
            return;
        }
        CardCreator cardCreator = new CardCreator(run.CardsCreated);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}