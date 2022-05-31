using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    
    public AudioSource tutorial;
    public AudioSource leftSide;
    public AudioSource rightSide;
    public AudioSource frontOn;
    public AudioSource civilian;

   
    void Start()
    {
       
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            tutorial.Play();
        }
    }
}
