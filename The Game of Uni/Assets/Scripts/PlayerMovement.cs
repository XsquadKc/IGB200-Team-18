using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Dice script;

    public Transform target;
    public float speed;
    


    // Start is called before the first frame update
    void Start()
    {
         


    }




    void FixedUpdate()
    {

        

        Vector3 a = transform.position;
        //Vector3 b = target.position;
        Vector3 c = GameObject.Find("Tile" + script.value.ToString()).transform.position;
        transform.position = Vector3.MoveTowards(a, c, speed);


    }
}
