using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GaneManager : MonoBehaviour
{
    Quiz quiz;
    EndScreen endScreen;
    StartScreen startScreen;
    void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        endScreen = FindObjectOfType<EndScreen>();
        startScreen = FindObjectOfType<StartScreen>();
    }
    void Start()
    {
        startScreen.gameObject.SetActive(true);
        quiz.gameObject.SetActive(false);
        endScreen.gameObject.SetActive(false);
    }
    void Update()
    {
        if (quiz.isComplete)
        {
            startScreen.gameObject.SetActive(false);
            quiz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            endScreen.ShowFinalScore();
        }
    }
    public void StartQuiz()
    {
        quiz.gameObject.SetActive(true);
        startScreen.gameObject.SetActive(false);
        endScreen.gameObject.SetActive(false);
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}