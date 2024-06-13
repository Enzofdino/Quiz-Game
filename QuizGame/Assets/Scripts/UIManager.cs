using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] Button[] answersButtons;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] GameObject menuWindow;
    [SerializeField] Button startButton;
    [SerializeField] TMP_Dropdown difficultyDropdown, themeDropdown;
    [SerializeField] Button nextButton;
    public void Start()
    {
        startButton.onClick.AddListener(() => GameManager.Instance.StartGame(difficultyDropdown.value, themeDropdown.value));
    }

    public void UpdateQuestion(Quiz quizSelected)
    {
        questionText.text = quizSelected.Question;

        for (int i = 0; i < answersButtons.Length; i++)
        {
            answersButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = quizSelected.Answers[i];
        }
    }

    public void SetMenu(bool active)
    {
        menuWindow.SetActive(active);
    }
    private void Starting()
    {
        nextButton.onClick.AddListener(() => QuizManager.instance.SelectQuiz(GameManager.Instance.Theme, GameManager.Instance.Difficulty));

    for(int i = 0; i < answersButtons.Length; i++)
     {
            int x = i;
            answersButtons[i].onClick.AddListener(() => QuizManager.instance.CheckAnswer(x));
            answersButtons[i].onClick.AddListener(() => nextButton.interactable = true);
        } 
    }
    public void UpdateQuestions(Quiz quizSelected)
    {
        for (int i = 0; i < answersButtons.Length; i++)
        {
            answersButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = quizSelected.Answers[i];
            answersButtons[i].interactable = true;
            answersButtons[i].GetComponent<Image>().color = Color.white;
        }
        nextButton.interactable = false;
    }
    public void HighlightButton(int correctAnswers,int answersSelected)
    {
        answersButtons[correctAnswers].GetComponent<Image>().color = Color.green;
        if (answersSelected!= correctAnswers)
        {
            answersButtons[answersSelected].GetComponent<Image>().color = Color.red;
        }

        for (int i = 0; i < answersButtons.Length; i++)
        {
            answersButtons[i].interactable = false;
        }
    }
}
