using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    void Awake()
    {
        if (Instance == null) 
        { 
            Instance = this; 
        } 
        else 
        { 
            Debug.Log("Warning: multiple " + this + " in scene!"); 
        }
    }

    public float socialScore;
    public float experienceScore;
    public float knowledgeScore;
    [SerializeField]
    GameObject scoreText;

    public FacultyCard playerCard;
    public List<ChanceCard> playerHand = new List<ChanceCard>();

    [SerializeField]
    ChanceCard[] chanceDeck;
    [SerializeField]
    FacultyCard[] degreeDeck;

    // Start is called before the first frame update
    void Start()
    {
        socialScore = 0;
        experienceScore = 0;
        knowledgeScore = 0;
        playerCard = degreeDeck[0];
}

    // Update is called once per frame
    void Update()
    {
        ScoreUpdate();
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "<color=\"green\">" + socialScore + " Social</color>\n"
            + " <color=\"blue\"> " + experienceScore + " Experience</color>\n"
            + "<color=\"red\">" + knowledgeScore + " Knowledge </color >";
    }

    void ScoreUpdate()
    {
        socialScore += playerCard.modifiers.S;
        experienceScore += playerCard.modifiers.E;
        knowledgeScore += playerCard.modifiers.K;
    }
    void PlayerTurn()
    {
        ScoreUpdate();
    }
}
