using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    public float speed = 8f;
    private Rigidbody rb;

    private Vector2 screenbounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector2(-speed, 0);

        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < screenbounds.y * 2)
        {
            Destroy(this.gameObject);
        }

       
    }
}
