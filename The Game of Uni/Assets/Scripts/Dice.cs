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



    // Start is called before the first frame update
    void Start()
    {
        //value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomGenerate()
    {
        Roll = Random.Range(1, 7);
        value += Roll;
        TextBox.GetComponent<TextMeshProUGUI>().text = Roll.ToString();
    }


}
