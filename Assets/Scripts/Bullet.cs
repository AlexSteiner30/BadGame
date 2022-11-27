using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameManager gameManager;

    public Rigidbody2D rb;

    public string enemyName;
    private GameObject enemy;

    public float dir;

    private void Start()
    {
        gameManager = GameObject.Find("Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();

        enemy = GameObject.Find(enemyName);
    }

    private void Update()
    {
        rb.AddForce(new Vector2(1 * dir, 0), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet1" || collision.gameObject.tag == "Bullet2")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        else if(collision.gameObject.tag == "Player1")
        {
            GetComponent<AudioSource>().mute = false;
            GetComponent<AudioSource>().Play();

            gameManager.ScorePlayer2();
            Destroy(this.gameObject);
        }

        else if (collision.gameObject.tag == "Player2")
        {
            GetComponent<AudioSource>().mute = false;
            GetComponent<AudioSource>().Play();

            gameManager.ScorePlayer1();

            Destroy(this.gameObject);
        }
    }
}
