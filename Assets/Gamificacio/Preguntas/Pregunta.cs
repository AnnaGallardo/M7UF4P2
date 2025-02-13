using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pregunta : MonoBehaviour

{
    public TMP_Text questionText;  // Cambié a TMP_Text
    public Image flagImage;
    public Button[] optionButtons;
    public TMP_Text[] optionTexts;  // Cambié a TMP_Text

    public Sprite[] flagSprites;
    public string[] countries;

    private int correctAnswerIndex;

    void Start()
    {
        SetNewQuestion();
    }
        void SetNewQuestion()
    {
        // Escoge un índice aleatorio para la bandera y el país
        correctAnswerIndex = Random.Range(0, countries.Length);

        // Asigna la bandera correspondiente
        flagImage.sprite = flagSprites[correctAnswerIndex];

        // Cambia el texto de la pregunta
        questionText.text = "¿De qué país es esta bandera?";

        // Mezcla las opciones y asigna las respuestas a los botones
        ShuffleOptions();

    void SetNewQuestion()
    {
        correctAnswerIndex = Random.Range(0, countries.Length);

        flagImage.sprite = flagSprites[correctAnswerIndex];
        questionText.text = "¿De qué país es esta bandera?";

        ShuffleOptions();
    }

    void ShuffleOptions()
    {
        var options = new string[countries.Length];
        for (int i = 0; i < countries.Length; i++)
        {
            options[i] = countries[i];
        }

        for (int i = 0; i < countries.Length; i++)
        {
            int j = Random.Range(0, countries.Length);
            string temp = options[i];
            options[i] = options[j];
            options[j] = temp;
        }

        for (int i = 0; i < optionTexts.Length; i++)
        {
            optionTexts[i].text = options[i];

            int index = i;  
            optionButtons[i].onClick.RemoveAllListeners();
            optionButtons[i].onClick.AddListener(() => OnOptionSelected(index, options[index]));
        }
    }

    void OnOptionSelected(int index, string selectedCountry)
    {
        if (index == correctAnswerIndex)
        {
            Debug.Log("¡Respuesta correcta!");
        }
        else
        {
            Debug.Log("Respuesta incorrecta, la respuesta correcta era: " + countries[correctAnswerIndex]);
        }
    }
}
}
