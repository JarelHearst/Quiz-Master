using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] String question = "Enter new question text here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex;
    //Arrays - The line of code below was incorrect, need to make an int value instead of an array of strings, it probabbly would be right, need to test later.
    //[SerializeField] string[] correctAnswer = new string[1];
    public string GetQuestion()
    {
        return question;
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }
}
