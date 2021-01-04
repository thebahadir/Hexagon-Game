using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    public float shrinkSpeed = 2.5f;
    private Rigidbody2D RB;


    void Start()
    {
        // Hexagon RigidBody2D'sine ulaş.
        RB = GetComponent<Rigidbody2D>();

        // Hexagon spawnerlarını 0 - 360 derece arasında random olarak döndür.
        RB.rotation = Random.Range(0f, 360f);

        // Spawn boyutları.
        transform.localScale = Vector3.one * 10f;

    }

    void Update()
    {
        // Hexagon spawnerlarının boyutunu küçülttük ve küçülme hızını ekle.
        transform.localScale -= Vector3.one * Time.deltaTime * shrinkSpeed;

        // Spawnelar 0.1'den küçük olduğu takdirde spawnerı yok et.
        if (transform.localScale.x < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        // Rastgele renk oluştur.
        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);

        // Oluşturulan rengi hexagon spawnerlarına ait materyale uygula.
        GetComponent<Renderer>().material.color = newColor;
    }
}
