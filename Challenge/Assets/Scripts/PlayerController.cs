using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;
    public Text lifeText;

    private Rigidbody rb;
    private int count;
    private int score;
    private int life;
    private object player;
    private object other;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        life = 3;
        SetCountText();
        winText.text = "";
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        rb.AddForce(movement * speed);
        if (Input.GetKey("escape"))
            Application.Quit();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetCountText();
        
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score - 1;
            life = life - 1;
            SetCountText();
        }
    }

    void SetCountText ()
    {
        lifeText.text = "Lives left: " + life.ToString();
        scoreText.text = "Score: " + score.ToString();
        countText.text = "Pickups collected: " + count.ToString();
        if (count >= 20)
        {
            winText.text = "Congratulations, You Win!";
        }
        if (life <= 0)
        {
            winText.text = "You died! Try again?";
            gameObject.CompareTag("Player");
            gameObject.SetActive(false);
        }

    }
}

