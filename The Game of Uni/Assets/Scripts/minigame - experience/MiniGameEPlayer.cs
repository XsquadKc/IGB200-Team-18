using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameEPlayer : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;
    private Vector2 playerDirection;

    private Vector2 screenbounds;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, directionY).normalized;

        if (transform.position.y < screenbounds.y )
        {
            Debug.Log("out of area");
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, playerDirection.y * speed);
    }

}
