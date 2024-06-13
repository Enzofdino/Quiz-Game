using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    Quiz.Difficulty difficulty;
    Quiz.Theme theme;

    QuizManager quizManager;

   
    public Quiz.Difficulty Difficulty { get => difficulty; }
    public Quiz.Theme Theme { get => theme; }

    private void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
    }

    //Inicia o jogo quando o bot�o iniciar do menu for pressionado
    public void StartGame(int difficultySelected, int themeSelected)
    {
        //Fechar a janela do menu
        UIManager.instance.SetMenu(false);
        //Atualizar a dificuldade e tema selecionado
        difficulty = (Quiz.Difficulty)difficultySelected;
        theme = (Quiz.Theme)themeSelected;
        //Solicitar um novo quiz
        quizManager.SelectQuiz(Theme, Difficulty);
    }
    public void GameOver()
    {
        //O jogo acaba
    }
    
}
