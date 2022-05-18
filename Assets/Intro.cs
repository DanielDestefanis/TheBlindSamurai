using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public AudioSource intro;

    void Update()
    {
        if (!intro.isPlaying)
        {
            SceneManager.LoadScene("Level");
        }
            
        
    }   
  
}
