using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    #region Singleton
    static public QuizManager instance;
    public void Awake()
    {
        instance = this;
    }

    #endregion
    [SerializeField] private Quiz[] quizList;
    [SerializeField] private Quiz currentQuiz;
     private int rightAnswers;

    public void SelectQuiz(Quiz.Theme themeSelected, Quiz.Difficulty dificultySelected)
    {
        Quiz quiz = quizList[Random.Range(0, quizList.Length)];
        if(quiz.GetDifficulty == dificultySelected && quiz.GetTheme == themeSelected)
        {
            currentQuiz = quiz;
            UIManager.instance.UpdateQuestion(currentQuiz);
        }
        else
        {
            SelectQuiz(themeSelected, dificultySelected);
        }
    }
    public void CheckAnswer(int answerSelected)
    {
         if(answerSelected == currentQuiz.CorrectAnswer)
        {
            rightAnswers++;
        }  
      else 
        {
            GameManager.Instance.GameOver();
        }
        UIManager.instance.HighlightButton(currentQuiz.CorrectAnswer, answerSelected);


    }
    
}
