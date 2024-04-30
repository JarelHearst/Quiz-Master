using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;
    public bool timerIsActive;
    public bool loadNextQuestion;
    public bool isAnsweringQuestion;
    public float fillFraction;
    float timerValue;
    void Update()
    {
        updateTimer();
    }
    public void StartTimer()
    {
        timerIsActive = true;
        isAnsweringQuestion = true;
        timerValue = timeToCompleteQuestion;
    }
    public void CancelTimer()
    {
        timerIsActive = false;
        timerValue = -1;
        fillFraction = 1;
    }

    void updateTimer()
    {
        timerValue -= Time.deltaTime;
        if (isAnsweringQuestion)
        {
            //timerIsActive = true;
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
    }
}
