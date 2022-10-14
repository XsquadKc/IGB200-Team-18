using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MGEGameManager : MonoBehaviour
{
    public bool playerDestroyed;
    public GameObject canvas1;
    public GameObject canvas2;

    public Text scoreUpdate;
    public Text scoreEnd;

    private float score;
    private float scoreIncrease;

    // Start is called before the first frame update
    void Start()
    {
        playerDestroyed = false;

        score += 0;
        scoreIncrease += 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDestroyed == false)
        {
            score += scoreIncrease + Time.deltaTime;

            scoreUpdate.text = score.ToString("0");
        }


        if (playerDestroyed == true)
        {
            canvas1.SetActive(false);
            canvas2.SetActive(true);

            scoreEnd.text = score.ToString("0");
        }
    }
}
