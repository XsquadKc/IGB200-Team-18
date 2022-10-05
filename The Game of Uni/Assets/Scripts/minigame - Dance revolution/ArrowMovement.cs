using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowMovement : MonoBehaviour
{
    public GameObject Left;

    public float speed = 40f;
    private Rigidbody2D rb;

    private bool inside;
    MinigameSocial minigameSocial;
    
    
    


    private Vector2 screenbounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);

        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        minigameSocial = GameObject.Find("GameManagerSocial").GetComponent<MinigameSocial>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < screenbounds.y * 2)
        {
            Destroy(this.gameObject);
        }

       

        // left arrow detection system
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (tag.Equals("LeftArrow"))
            {
                if (inside == true)
                {

                    minigameSocial.value += 10;
                    minigameSocial.score.text = minigameSocial.value.ToString();

                    Destroy(this.gameObject);

                }
            }


        }

        // right arrow detection system
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (tag.Equals("RightArrow"))
            {
                if (inside == true)
                {
                    minigameSocial.value += 10;
                    minigameSocial.score.text = minigameSocial.value.ToString();

                    Destroy(this.gameObject);
                }
            }


        }

        // up arrow detection system
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (tag.Equals("UpArrow"))
            {
                if (inside == true)
                {
                    minigameSocial.value += 10;
                    minigameSocial.score.text = minigameSocial.value.ToString();

                    Destroy(this.gameObject);
                }
            }


        }

        // down arrow detection system
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            if (tag.Equals("DownArrow"))
            {
                if (inside == true)
                {
                    minigameSocial.value += 10;
                    minigameSocial.score.text = minigameSocial.value.ToString();

                    Destroy(this.gameObject);

                    
                }
            }


        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inside = true;
        Debug.Log("entered");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inside = false;
        Debug.Log("exited");
    }
}
