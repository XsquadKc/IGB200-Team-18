using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GM");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        
    }

    public float socialScore;
    public float experienceScore;
    public float knowledgeScore;
    public bool examComplete;
    public GameObject scoreText;
    public GameObject degreeCard;
    public GameObject player;
    public GameObject choiceButtons;
    public GameObject continueButton;
    public GameObject socialBar;
    public GameObject experienceBar;
    public GameObject knowledgeBar;
    public GameObject canvas;

    public int tile;
    public Vector3 previousPosition;
    public int savedValue;

    [SerializeField]
    GameObject cardPrefab;
    int currentFunction;
    public bool injured;
    GameObject currentCard;

    public FacultyCard playerCard;
    public List<ChanceCard> playerHand = new List<ChanceCard>();

    [SerializeField]
    public ChanceCard[] chanceDeck;
    [SerializeField]
    public FacultyCard[] degreeDeck;

    // Start is called before the first frame update
    void Start()
    {
        socialScore = 0;
        experienceScore = 0;
        knowledgeScore = 0;
        playerCard = degreeDeck[Random.Range(0, degreeDeck.Length)];

        if (SceneManager.GetActiveScene().name == "MainGame")
        {
            setupObjectReferences();
        }
        
    }
    

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "MainGame")
        {
            socialBar.GetComponent<RectTransform>().sizeDelta = new Vector2 (socialScore, 40);
            experienceBar.GetComponent<RectTransform>().sizeDelta = new Vector2(experienceScore, 40);
            knowledgeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(knowledgeScore, 40);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainGame")
        {
            setupObjectReferences();
        }
    }

    void setupObjectReferences()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText");
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.FindGameObjectWithTag("Canvas");

        RectTransform[] canvasChildren = canvas.gameObject.GetComponentsInChildren<RectTransform>();
        for (int i = 0; i < canvasChildren.Length; i++)
        {
            if (canvasChildren[i].gameObject.CompareTag("ChoiceButtons"))
            {
                choiceButtons = canvasChildren[i].gameObject;
            }
            else if (canvasChildren[i].gameObject.CompareTag("Continue"))
            {
                continueButton = canvasChildren[i].gameObject;
            }
        }
        degreeCard = GameObject.FindGameObjectWithTag("DegreeCard");
        degreeCard.GetComponent<Image>().sprite = playerCard.sprite;
        socialBar = GameObject.FindGameObjectWithTag("Social Bar");
        experienceBar = GameObject.FindGameObjectWithTag("Experience Bar");
        knowledgeBar = GameObject.FindGameObjectWithTag("Knowledge Bar");
        
        choiceButtons.SetActive(false);
        continueButton.SetActive(false);
    }

    public void ScoreUpdate()
    {
        socialScore += playerCard.modifiers.S;
        experienceScore += playerCard.modifiers.E;
        knowledgeScore += playerCard.modifiers.K;
    }
    public void PlayerTurn(string condition)
    {
        
        if (condition == "chance")
        {
            ChanceCard drawnCard = chanceDeck[Random.Range(0, chanceDeck.Length)];
            currentCard = Instantiate(cardPrefab);
            currentCard.GetComponent<Image>().sprite = drawnCard.sprite;
            currentCard.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
            currentCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
            currentCard.GetComponent<RectTransform>().localScale = new Vector3(2, 2, 1);
            CardChoice(drawnCard.specialFunction);
        }

    }
    public void CompleteTurn()
    {
        GameObject.Destroy(currentCard);
        ScoreUpdate();
        player.GetComponent<PlayerMovement>().DiceScript.TextBox.gameObject.SetActive(false);
        player.GetComponent<PlayerMovement>().DiceScript.diceButton.gameObject.SetActive(true);
    }

    public void CardChoice(int functionID)
    {
        if (functionID == 1)
        {
            currentFunction = 1;
            choiceButtons.SetActive(true);
        }
        if (functionID == 2)
        {
            currentFunction = 2;
            continueButton.SetActive(true);
        }
    }

    public void PlayCard()
    {
        if (currentFunction == 1)
        {
            float rand = Random.Range(0, 1);
            if (rand <= 0.17f)
            {
                injured = true;
            }
            socialScore += 20;
            CompleteTurn();
        }
        if (currentFunction == 2)
        {
            float rand = Random.Range(0, 1);
            if (rand > 0.75f)
            {
                socialScore += 15;
                knowledgeScore += 15;
            }
            else
            {
                socialScore += 10;
                knowledgeScore += 10;
            }
            CompleteTurn();
        }
    }

    

}
