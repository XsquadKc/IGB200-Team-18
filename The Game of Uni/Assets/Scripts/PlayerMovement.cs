using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Dice script;

    public Transform target;
    public float speed;
    private Vector3 previousPosition;

    public float x;
    public float y;
    public float z;
    public int savedValue;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("x") && PlayerPrefs.HasKey("y") && PlayerPrefs.HasKey("z") && PlayerPrefs.HasKey("sv"))
        {
            x = PlayerPrefs.GetFloat("x");
            y = PlayerPrefs.GetFloat("y");
            z = PlayerPrefs.GetFloat("z");
            script.value = PlayerPrefs.GetInt("sv");
            Vector3 posVec = new Vector3(x, y, z);
            transform.position = posVec;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Minigame")
        {
            x = transform.position.x;
            PlayerPrefs.SetFloat("x", x);
            y = transform.position.y;
            PlayerPrefs.SetFloat("y", y);
            z = transform.position.z;
            PlayerPrefs.SetFloat("z", z);
            savedValue = script.value;
            PlayerPrefs.SetInt("sv", savedValue);

            previousPosition = transform.position;

            SceneManager.LoadScene(sceneName: "Exam Minigame");
            Debug.Log("trigger event");
        }

        
    }

    public void runMinigame()
    {
        x = transform.position.x;
        PlayerPrefs.SetFloat("x", x);
        y = transform.position.y;
        PlayerPrefs.SetFloat("y", y);
        z = transform.position.z;
        PlayerPrefs.SetFloat("z", z);
        savedValue = script.value;
        PlayerPrefs.SetInt("sv", savedValue);

        previousPosition = transform.position;

        SceneManager.LoadScene(sceneName: "Exam Minigame");
       // Debug.Log("trigger event");
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(sceneName: "SampleScene");
    }


    void FixedUpdate()
    {

        

        Vector3 a = transform.position;
        Vector3 c = GameObject.Find("Tile" + script.value.ToString()).transform.position;
        transform.position = Vector3.MoveTowards(a, c, speed);

        


    }
}
