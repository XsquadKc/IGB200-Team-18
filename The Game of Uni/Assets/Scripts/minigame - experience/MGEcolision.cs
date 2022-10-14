using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGEcolision : MonoBehaviour
{

    private GameObject player;
    private GameObject manager;

    public MGEGameManager playerDead;

    //private GameObject canvas1;
    //private GameObject canvas2;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MGEPlayer");
        manager = GameObject.FindGameObjectWithTag("GameManagerE");

        playerDead = manager.GetComponent<MGEGameManager>();

        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "MGEPlayer")
        {
            Destroy(player.gameObject);
            Debug.Log("game over scrub");

           playerDead.playerDestroyed = true;
             
      
        }

    }
}
