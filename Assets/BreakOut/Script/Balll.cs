using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Balll : MonoBehaviour
{
    public float boundary = -5.5f;
    public float maxSpeed = 15f;
    private Rigidbody2D rb;

    private int score = 0;
    private int lives = 3;
    public TextMeshProUGUI scoreText;
    public GameObject[] livesImage;
    public GameObject gameoverPanel;
    public GameObject youWinPanel;
    private int brickCount;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        brickCount = FindObjectOfType<BrickSpawner>().transform.childCount;
        rb.velocity = Vector2.down * 5f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y < boundary)
        {
            if (lives <= 0)
            {
                GameOver();
            }
            else
            {
                transform.position = Vector3.zero;
                rb.velocity = Vector2.down * 5f;
                lives--;
                livesImage[lives].SetActive(false);
            }
        }
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            score += 10;
            brickCount--;
            if (brickCount <= 0)
            {
                youWinPanel.SetActive(true);
                Time.timeScale = 0;
            }
            scoreText.text = score.ToString("0000");
        }
    }

    private void GameOver()
    {
        gameoverPanel.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
    }
}