using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudio : MonoBehaviour
{

    

    private AudioSource pieceMove;


    // Start is called before the first frame update
    void Start()
    {
        pieceMove = GetComponent<AudioSource>();
    }

    public void play()
    {
        pieceMove.Play();
    }
}
