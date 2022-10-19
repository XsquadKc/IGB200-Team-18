using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class MinigameSocial : MonoBehaviour
{


    public GameObject leftbutton;
    public GameObject rightbutton;
    public GameObject upbutton;
    public GameObject downbutton;

    public Text score;
    public int value;

    private Animation left;
    private Animation right;
    private Animation up;
    private Animation down;

    public GameObject Lspawn;
    public GameObject Uspawn;
    public GameObject Dspawn;
    public GameObject Rspawn;


    public GameObject LArrow;
    public GameObject UArrow;
    public GameObject DArrow;
    public GameObject RArrow;

    public GameObject canvas;
    public float wait = 1f;


    private GameManager gameManager;

    public Pattern[] song;
    private static List<Pattern> unspawnedArrows;
    private int listPos = 0;
    //private static int remainingArrows = 5;
    private Pattern currentArrow;

    [System.Serializable]
    public class Pattern
    {
        public bool isLeft;
        public bool isUp;
        public bool isDown;
        public bool isRight;

        public float wait; 
        //spawner location/ arrow  type
        // wait before next arrow

    }


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        left = leftbutton.GetComponent<Animation>();
        right = rightbutton.GetComponent<Animation>();
        up = upbutton.GetComponent<Animation>();
        down = downbutton.GetComponent<Animation>();
        //value = 0;

        //if (unspawnedArrows == null || unspawnedArrows.Count == 0)
        // {
        //   unspawnedArrows = song.ToList<Pattern>();
        //}

        unspawnedArrows = song.ToList<Pattern>();

        setArrow();

        spawnArrow();
    }


    //IEnumerator Start()
    //{
    //    for (int a = 1; a < remainingArrows; a++)
    //    {
    //        //set first arrow
    //        //spawn first arrow
    //        //move to second arrow in list
    //        //delay
    //        //spawn second arrow
    //        //ect
    //    }
    //}


    void setArrow()
    {
        if(listPos < unspawnedArrows.Count)
        {
            currentArrow = unspawnedArrows[listPos];
        }
        else
        {
            gameManager.socialComplete = true;
            gameManager.socialScore += value;
            SceneManager.LoadScene(sceneName: "MainGame");
        }
        
        
    }

    void spawnArrow()
    {
        // add courontine to start for waitfor wait 

        //instantiate the arrow
        //left
       // int arrowAmount = unspawnedArrows.Count;
        //currentArrow = unspawnedArrows[5];


        if (currentArrow.isLeft == true)
        {
            GameObject l = Instantiate(LArrow) as GameObject;
            l.transform.SetParent(canvas.transform, false);
            l.transform.position = Lspawn.transform.position;

            listPos += 1;
            StartCoroutine(NextArrow());
        }
        //up
        if (currentArrow.isUp == true)
        {
            GameObject u = Instantiate(UArrow) as GameObject;
            u.transform.SetParent(canvas.transform, false);
            u.transform.position = Uspawn.transform.position;

            listPos += 1;
            StartCoroutine(NextArrow());
        }
        //down
        if (currentArrow.isDown == true)
        {
            GameObject d = Instantiate(DArrow) as GameObject;
            d.transform.SetParent(canvas.transform, false);
            d.transform.position = Dspawn.transform.position;

            listPos += 1;
            StartCoroutine(NextArrow());
        }
        //right
        if (currentArrow.isRight == true)
        {
            GameObject r = Instantiate(RArrow) as GameObject;
            r.transform.SetParent(canvas.transform, false);
            r.transform.position = Rspawn.transform.position;

            listPos += 1;
            StartCoroutine(NextArrow());
        }

        
        //unspawnedArrows++;
    }


    //IEnumurator
    // run the spawn arrow 
    IEnumerator NextArrow()
    {
        //unspawnedArrows.Remove(currentArrow);

        yield return new WaitForSeconds(currentArrow.wait);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        setArrow();
        spawnArrow();
    }


    // Update is called once per frame
    void Update()
    {

        

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
           // Debug.Log("left key pressed");
            left.Play("Press");

            //score.text = value.ToString();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            up.Play("Press");
            //score.text = value.ToString();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            
            down.Play("Press");
            //score.text = value.ToString();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            
            right.Play("Press");
            //score.text = value.ToString();
        }


        
    }


  

}
