using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using TMPro;

public class MiniGameManager : MonoBehaviour
{

    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private static int remainingQuestions = 5;

    private Question currentQuestion;

    [SerializeField]
    private Text factText;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    [SerializeField]
    private Text trueAnswertext;
    [SerializeField]
    private Text falseAnswertext;

    [SerializeField]
    private Animator animator;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();
        //Debug.Log(currentQuestion.fact + currentQuestion.isTrue);
        Debug.Log(remainingQuestions);
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;
        remainingQuestions -= 1;

        if (remainingQuestions <= 0)
        {
            gameManager.knowledgeComplete = true;
            SceneManager.LoadScene(sceneName: "MainGame");

            

        }

        if (currentQuestion.isTrue)
        {
            trueAnswertext.text = "CORRECT";
            falseAnswertext.text = "WRONG";
        }
        else
        {
            trueAnswertext.text = "WRONG";
            falseAnswertext.text = "CORRECT";
        }
        
    }


    IEnumerator TransitionNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UserSelectTrue()
    {


        animator.SetTrigger("True");
        if (currentQuestion.isTrue)
        {
            //correct
            //score
          
        }
        else
        {
            //wrong
        }


        StartCoroutine(TransitionNextQuestion());
    }

    public void UserSelectFalse()
    {


        animator.SetTrigger("False");
        if (!currentQuestion.isTrue)
        {
            //correct
            
            

        }
        else
        {
            //wrong
        }

        StartCoroutine(TransitionNextQuestion());
    }

}

