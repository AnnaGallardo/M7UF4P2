using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ExcelReader : MonoBehaviour
{
    public string csv = "Database"; // nombre del excel
    public List<string> Answers, Questions; // lista de preguntas y respuestas
    public Button questionButton; //acces botons
    public TextMeshProUGUI answerText; // text
    void Start() 
    {
        TextAsset text = Resources.Load<TextAsset>(csv); // carrega el fitxer "excel"
        if(csv!= null)
        {
            ReadCSV(text.text); 
            answerText.text = "";
        }
    }
    private void ReadCSV(string csv)
    {
        string[] rows = csv.Split("\n"); //que separe la información con un salto de linea.
        for (int i=0; i<rows.Length; i++) // bucle que se haga 5 veces (porque hay 5 preguntas)  
        {
            string[] cells = rows[i].Split(","); //tendrá dos valores (pregunta y respuesta)
            Questions.Add(cells[0]); //la primera posicion se le pasa a preguntas.
            Button newQButton = Instantiate(questionButton, questionButton.transform.parent); // Instantiate: es como duplicar el botón original
            newQButton.GetComponentInChildren<TextMeshProUGUI>().text = cells[0]; // le da al botón el valor de la pregunta. 
            var currentIndex = i; //
            newQButton.onClick.AddListener(() => AnswerTheQuestion(currentIndex)); //AdListener: es como el Onclik del botón.
            /*newQButton.onClick.AddListener(delegate { 
                AnswerTheQuestion(currentIndex);
            } );*/
            Answers.Add(cells[1]); 
        }
        questionButton.gameObject.SetActive(false); /* desactiva el botón inicial, ya que ha hecho 5 "copias2 del original
                                                    por lo que tendrá 6. el original se desactiva.*/
    }
    public void AnswerTheQuestion(int i) 
    {
        answerText.text = Answers[i]; // el texto de la respuesta es el de de la "I" si el texto es 1, sale la respuesta 1.
    }
}
