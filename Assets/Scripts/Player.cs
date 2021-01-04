using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float movementSpeed = 500f;
    private float movement = 0f;
    private GameManager game;
    public Transform effect;
    public RectTransform gameOver;
    private Spawner spawner;

    [HideInInspector]
    public bool dead;


    private void Awake()
    {
        //Game Over ekranını oluşturan panel gizlendi.
        gameOver.localScale = new Vector3(0, 0);
    }

    void Start()
    {
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        dead = false;
    }

    void Update()
    {
       
        if (!dead)
        {
            movement = Input.GetAxisRaw("Horizontal");
        }

        else
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Game");
            }
        }

    }

     void FixedUpdate()
    {
        // Player sıfır ekseninde, EnergySphere objesinin çevresinde döndürüldü.
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * -movementSpeed * Time.fixedDeltaTime);
    }

     void OnTriggerEnter2D(Collider2D collision)
    {        

        if (collision.gameObject.CompareTag("Hexagon") && !dead) 
        {                                                       
            Death();
            Invoke(nameof(GameOver), 0.5f);
            Destroy(spawner);
            game.scoreText.fontSize = 0;
        }

        else if (collision.gameObject.CompareTag("Point"))
        {
            game.score++;
            game.ChangeScore();
        }
    }

    void Death()
    {
        dead = true;
        game.music.Stop();
        game.effectsSounds.clip = game.deathSound;
        game.effectsSounds.Play();
        game.effectsSounds2.clip = game.gameOverSound;
        game.effectsSounds2.Play();

        Instantiate(effect, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void GameOver()
    {
        //Game Over ekranını oluşturan panel gösterildi.
        gameOver.localScale = new Vector3(1, 1);
    }

}