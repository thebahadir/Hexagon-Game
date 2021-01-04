using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    
    public GameObject gameObjects;
    private bool gameStarted;
    public Text scoreText;
    public Text scoreText2;
    public int score;
    

    public AudioSource music;
    public AudioSource effectsSounds;
    public AudioClip deathSound;
    public AudioSource effectsSounds2;
    public AudioClip gameOverSound;


    void Start()
    {
        gameStarted = false;
        scoreText.text = "0";

    }

    void Update()
    {
        if (!gameStarted)
        {
                gameStarted = true;
                gameObjects.SetActive(true);
                scoreText.text = "0";
        }

    }

    public void ChangeScore()
    {
        scoreText.text = score.ToString();
        scoreText2.text = "Score\n" + score.ToString();
    }
}
