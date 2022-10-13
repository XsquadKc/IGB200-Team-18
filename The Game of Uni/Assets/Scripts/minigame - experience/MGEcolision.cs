using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGEcolision : MonoBehaviour
{

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MGEPlayer");
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "MGEPlayer")
        {
            Destroy(player.gameObject);
            Debug.Log("game over scrub");
        }

    }
}
