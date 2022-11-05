using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Dice DiceScript;

    public Transform target;
    public float speed;
    public int numTiles;
    public int currentTile;
    private GameManager gameManager;

    public GameObject enemy;
    public int enemyCurrentTile;


    
    private AudioSource piece;
    
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        currentTile = 0;
        numTiles = 56;

        
        piece = GetComponent<AudioSource>();

        if (gameManager.previousPosition != new Vector3(0,0,0) && this.gameObject.CompareTag("Player"))
        {
            DiceScript.value = gameManager.savedValue;
            currentTile = gameManager.tile;
            transform.position = gameManager.previousPosition;
        }
        else if (gameManager.previousPosition != new Vector3(0, 0, 0) && this.gameObject.CompareTag("Enemy"))
        {
            enemyCurrentTile = gameManager.enemyTile;
            transform.position = gameManager.enemyPreviousPosition;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (this.gameObject.CompareTag("Player"))
        {
            if (collider.tag == "Knowledge Minigame" && currentTile == DiceScript.value - 1 && gameManager.knowledgeComplete == false)
            {
                collider.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                runMinigame("Exam Minigame");
            }
            if (collider.tag == "Experience Minigame" && currentTile == DiceScript.value - 1 && gameManager.experienceComplete == false)
            {
                collider.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                runMinigame("Experience Mini-game");
            }
            if (collider.tag == "Social Minigame" && currentTile == DiceScript.value - 1 && gameManager.socialComplete == false)
            {
                collider.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                runMinigame("Social Mini-game");
            }
            if (collider.tag == "Chance" && currentTile == DiceScript.value - 1)
            {
                gameManager.PlayerTurn("chance");
            }
        }
    }

    public void runMinigame(string name)
    {
        if (this.gameObject.CompareTag("Player"))
        {
            gameManager.savedValue = DiceScript.value;
            gameManager.previousPosition = transform.position;
            gameManager.tile = currentTile;
            gameManager.enemyTile = enemyCurrentTile;
            gameManager.enemyPreviousPosition = enemy.transform.position;


            SceneManager.LoadScene(sceneName: name);
        }
    }


    void FixedUpdate()
    {
        if (this.gameObject.CompareTag("Player"))
        {
            if (DiceScript.value > numTiles - 1)
            {
                DiceScript.value = numTiles;
            }
            Vector3 a = transform.position;
            Vector3 b;
            if (currentTile < DiceScript.value)
            {
                b = GameObject.Find("Tile" + (currentTile + 1).ToString()).transform.position;
                b.y = a.y;

                if (a != b)
                {
                    transform.position = Vector3.MoveTowards(a, b, speed);
                }
                else
                {
                    currentTile += 1;
                }
            }
            else
            {
                gameManager.moving = false;
            }
            if ((currentTile > 15 && currentTile < 28) || (currentTile > 42 && currentTile < 56))
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            
        }
        else if (this.gameObject.CompareTag("Enemy"))
        {
            if (gameManager.enemyMoving)
            {
                EnemyTurn();
            }
            if ((enemyCurrentTile > 15 && enemyCurrentTile < 28) || (enemyCurrentTile > 42 && enemyCurrentTile < 56))
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        
    }

    void EnemyTurn()
    {

        if (gameManager.enemyValue > numTiles - 1)
        {
            gameManager.enemyValue = numTiles;
        }
        Vector3 a = this.transform.position;
        Vector3 b;
        if (enemyCurrentTile < gameManager.enemyValue)
        {
            b = GameObject.Find("Tile" + (enemyCurrentTile + 1).ToString()).transform.position;
            b.y = a.y;

            if (a != b)
            {
                this.transform.position = Vector3.MoveTowards(a, b, speed);
            }
            else
            {
                enemyCurrentTile += 1;
            }
        }
        else
        {
            gameManager.enemyMoving = false;
            DiceScript.diceButton.gameObject.SetActive(true);
        }
    }


    public void play()
    {
        piece.Play();
        
    }
}
