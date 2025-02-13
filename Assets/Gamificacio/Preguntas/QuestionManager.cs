using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public Button[] options;
    public TextMeshProUGUI Pregunta, Feedback;
    public OptionSO[] OptionsSO;
    public Image image;
    
    void Start()
    {
        GenerateQuestion();
    }
    void GenerateQuestion()
    {
        int BotonRespuestaCorrecta = Random.Range(0,2);
        int BanderaCorrecta = Random.Range(0, options.Length);
        
        for(int i=0; i<options.Length; i++)
        {
            options[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "";
            options[i].onClick.RemoveAllListeners();
        }
        options[BotonRespuestaCorrecta].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = OptionsSO[BanderaCorrecta].Country;
        options[BotonRespuestaCorrecta].onClick.AddListener(()=>EvaluateQuestion(true));
        image.sprite = OptionsSO[BanderaCorrecta].Flag;
        for(int i=0; i<options.Length; i++)
        {
            if(options[i].GetComponentInChildren<TextMeshProUGUI>().text.Equals(""))
            {
                int banderaRandom;
                do{
                    banderaRandom = Random.Range(0,options.Length);
                }while(banderaRandom == BanderaCorrecta);
            options[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = OptionsSO[banderaRandom].Country;
            options[i].onClick.AddListener(()=>EvaluateQuestion(false));
            }
        }

    }
    void EvaluateQuestion(bool isCorrect)
    {
        if(isCorrect)
        {
            Feedback.text = "Correcto";

        }
        else
        {
            Feedback.text = "Incorrecto";

        }
        GenerateQuestion();
    }
}
