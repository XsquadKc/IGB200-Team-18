using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Dice script;

    public Transform target;
    public float speed;
    public int numTiles;
    


    // Start is called before the first frame update
    void Start()
    {

        numTiles = 14;

    }




    void FixedUpdate()
    {

        

        Vector3 a = transform.position;
        //Vector3 b = target.position;
        Vector3 c;
        if (script.value <= numTiles-1)
        {
             c = GameObject.Find("Tile" + script.value.ToString()).transform.position;
        }
        else
        {
            c = GameObject.Find("Tile" + numTiles.ToString()).transform.position;
        }
        if (a != c)
        {
            transform.position = Vector3.MoveTowards(a, c, speed);
        }
        


    }
}
