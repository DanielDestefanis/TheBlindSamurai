using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuNarration : MonoBehaviour
{
    public AudioSource storyMode;
    public AudioSource tutorial;
    public AudioSource endlessMode;

    int number = 0;
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            number = number + 1;
        }

        if (number == 1)
        {
            tutorial.Play();
        }

        if (number == 2)
        {
            storyMode.Play();
        }

        if (number == 3)
        {
            endlessMode.Play();
        }

        if (number == 4)
        {
            number = 0;
        }   

        Debug.Log(number);
    }
}
