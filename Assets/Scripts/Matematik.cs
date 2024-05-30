using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Matematik : MonoBehaviour{
 public TMP_Text questionText;
    public TMP_InputField answerInput;

    private int num1;
    private int num2;
    public int correctAnswer;
    private int enteredAnswer;
    public  bool isCorrect = false;


    void Start()
    {
        GenerateQuestion();
    }

    public void GenerateQuestion()
    {
        // Generate two random numbers for the question
        num1 = Random.Range(1, 10);
        num2 = Random.Range(1, 10);

        // Calculate the correct answer
        correctAnswer = num1 * num2;

        // Display the question
        questionText.text = num1 + " * " + num2 + " = ?";
    }

    public void CheckAnswer(int enter)
    {
        enteredAnswer = enter;
        // Get the entered answer from the input field
     
        if (int.TryParse(answerInput.text, out enteredAnswer))
        {
            // Compare the entered answer with the correct answer
            if (enteredAnswer == correctAnswer)
            {
                Debug.Log("Correct!");
                isCorrect = true;

            }
            else
            {
                
            }
        }
        else
        {
            Debug.Log("Invalid answer!");
        }
    }
}
