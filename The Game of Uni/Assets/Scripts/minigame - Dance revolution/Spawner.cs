using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject LArrow;
    public GameObject canvas; 
    public float respawnTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wave());
    }

    private void spawnArrow()
    {
        GameObject l = Instantiate(LArrow) as GameObject;
        l.transform.SetParent(canvas.transform, false);
        l.transform.position = this.transform.position;
    }

    IEnumerator wave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnArrow();
        }

        
    }
}
