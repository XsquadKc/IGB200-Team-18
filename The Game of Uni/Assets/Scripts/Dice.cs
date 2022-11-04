using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Dice : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject diceButton;
    public int Roll;
    public int value;
    private GameManager gameManager;

    private AudioSource diceRoll;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

        //diceRoll = GetComponent<AudioSource>();
        diceRoll = GameObject.Find("Canvas").GetComponent<AudioSource>();
        //value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameManager.yearNumber = (value + 1) / 14;
    }

    public void RandomGenerate()
    {
        diceRoll.Play();
        Roll = Random.Range(1, 7);
        value += Roll;
        TextBox.GetComponent<TextMeshProUGUI>().text = Roll.ToString();
        gameManager.moving = true;
    }


}
