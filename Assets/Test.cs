using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Test : MonoBehaviour
{

    public AudioSource[] directions;
    public ScriptableSounds[] soundObjects;
    public AudioClip[] parrySounds;

    public AudioSource left;
    public AudioSource right;
    public AudioSource front;
    public AudioSource parry;
    public AudioSource civilian;
    public AudioSource civilianDeath;
    public AudioSource death;
    public AudioClip loseLifeSound;
    public AudioSource battleMusic;
    public AudioSource introMusic;

    public GameObject leftPanel;
    public GameObject rightPanel;
    public GameObject frontPanel;

    public GameObject leftPanelTest;
    public GameObject rightPanelTest;
    public GameObject frontPanelTest;

    public Text highScore;
    int scoreCount;

    int highScoreCount;

    public Text lives;
    int playerLives = 3;

    public Text gameOverText;
    public GameObject restartButton;

    public Text score;

    float clipTimer;
    float introMusicTimer;
       
    void Start()
    {
        CallAudio();      

        left = left.GetComponent<AudioSource>();
        right = right.GetComponent<AudioSource>();
        front = front.GetComponent<AudioSource>();
        parry = parry.GetComponent<AudioSource>();
        civilian = civilian.GetComponent<AudioSource>();
        civilianDeath = civilianDeath.GetComponent<AudioSource>();
        death = death.GetComponent<AudioSource>();

        lives.text = "Lives: " + playerLives;

        gameOverText.enabled = false;
        restartButton.SetActive(false);

        highScore.enabled = false;
        score.text = "" + scoreCount;

        Time.timeScale = 1;

        highScoreCount = PlayerPrefs.GetInt("highScoreCount", highScoreCount);
        highScore.text = "High Score: " + highScoreCount.ToString();     
       
    }
    
    void Update()
    {
        LeftAudio();
        RightAudio();
        FrontAudio();
        Civilian();
        PlayerDeath();        

        Debug.Log(scoreCount);  
        introMusicTimer += Time.deltaTime; 

        Debug.Log(introMusicTimer);
    }  

    public void LeftAudio()
    {
        if (left.isPlaying)
        {
            Debug.Log("left");
            leftPanel.SetActive(true);
            clipTimer += Time.deltaTime;

            if (Input.GetMouseButtonDown(0))
            {
                leftPanelTest.SetActive(true);
                Parry();                
                left.Stop();
                scoreCount++;
                score.text = "" + scoreCount;
                clipTimer = 0;
            }

            else if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
            {
                left.Stop();                
                clipTimer = 0;
                LoseLife();
            }
            //when left clip finishes
            else if (clipTimer + 0.1f >= left.clip.length)
            {
                playerLives = playerLives - 1;
                lives.text = "Lives: " + playerLives;
                clipTimer = 0;
                death.PlayOneShot(loseLifeSound); 
            }
        }
        else
        {
            leftPanel.SetActive(false);
            leftPanelTest.SetActive(false);         

        }        
    }
    public void RightAudio()
    {
        if (right.isPlaying)
        {
            Debug.Log("right");
            rightPanel.SetActive(true);
            clipTimer += Time.deltaTime;            

            if (Input.GetMouseButtonDown(1))
            {
                rightPanelTest.SetActive(true);
                Parry();
                right.Stop();
                scoreCount++;
                score.text = "" + scoreCount;
                clipTimer = 0;
            }

            else if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(2))
            {
                right.Stop();               
                clipTimer = 0;
                LoseLife();
            }

            //when right clip finishes
            else if (clipTimer + 0.1f >= right.clip.length)
            {
                playerLives = playerLives - 1;
                lives.text = "Lives: " + playerLives;
                clipTimer = 0;
                death.PlayOneShot(loseLifeSound);
            }
        }
        else
        {
            rightPanel.SetActive(false);
            rightPanelTest.SetActive(false);            
        }
    }
    public void FrontAudio()
    {
        if (front.isPlaying)
        {           
            Debug.Log("front");
            frontPanel.SetActive(true);
            clipTimer += Time.deltaTime;

            if (Input.GetMouseButtonDown(2))
            {
                frontPanelTest.SetActive(true);
                Parry();                 

                front.Stop();
                scoreCount++;
                score.text = "" + scoreCount;
                clipTimer = 0;
            }

            else if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            { 
                
                front.Stop();               
                clipTimer = 0;
                LoseLife();
            }

            //when front clip finishes
            else if (clipTimer + 0.1f >= front.clip.length)
            {
                playerLives = playerLives - 1;
                lives.text = "Lives: " + playerLives;
                clipTimer = 0;
                death.PlayOneShot(loseLifeSound);
            }
        }
        else
        {
            frontPanel.SetActive(false);
            frontPanelTest.SetActive(false);            
        }
    }
    public void Civilian()
    {
        if(civilian.isPlaying)
        {
            clipTimer += Time.deltaTime;            

            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
            {
                civilian.Stop();
                civilianDeath.Play();
                scoreCount -= 3;
                score.text = "" + scoreCount;
                clipTimer = 0;
                playerLives = playerLives - 1;
                lives.text = "Lives: " + playerLives;
            }         
            
            else if (clipTimer + 0.1f >= civilian.clip.length)
                {
                    scoreCount++;
                    score.text = "" + scoreCount;
                    clipTimer = 0;
                }            
        }
    }

    public void CallAudio()
    {
       
        if (scoreCount < 5)
            {
                Invoke("Yells", 5);

            }
        else
            {
                Invoke("Yells", 2);
                Debug.Log("HARD MODE");
            }
        
    }

    public void Yells()
    {
        var source = directions[Random.Range(0, directions.Length)]; // Grab random source

        //var soundObject = soundObjects[Random.Range(0, soundObjects.Length)];
        if (source == directions[0])
        {
            source.clip = soundObjects[2].clipList[Random.Range(0, soundObjects[2].clipList.Count)];
        }

        else if (source == directions[1])
        {
            source.clip = soundObjects[0].clipList[Random.Range(0, soundObjects[0].clipList.Count)];
        }

        else if (source == directions[2])
        {
            source.clip = soundObjects[1].clipList[Random.Range(0, soundObjects[1].clipList.Count)];
        }

        else if (source == directions[3])
        {
            source.clip = soundObjects[3].clipList[Random.Range(0, soundObjects[3].clipList.Count)];
        }   
              // Grab random clip   

        source.Play();             

        CallAudio();
    }  

    public void Parry()
    {
        parry.clip = parrySounds[Random.Range(0, parrySounds.Length)];
        parry.Play();  
    }

    public void PlayerDeath()
    {
        if (playerLives <= 0)
        {            
            restartButton.SetActive(true);
            gameOverText.enabled = true;
            Time.timeScale = 0;
            highScore.enabled = true;

            if (scoreCount > highScoreCount)
            {
                highScoreCount = scoreCount;
                highScore.text = "High Score: " + scoreCount;

                PlayerPrefs.SetInt("highScoreCount", highScoreCount);
            }
        }
    } 
    public void LoseLife()
        {
            death.PlayOneShot(loseLifeSound);
            playerLives = playerLives - 1;
            lives.text = "Lives: " + playerLives;
        }   
}

