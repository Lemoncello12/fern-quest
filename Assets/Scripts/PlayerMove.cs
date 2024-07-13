using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{


    public float speed = 5f;
    public Rigidbody2D rb;
    public int currentHealth = 0;
    public int maxHealth = 20;
    public int keys = 0;
    public GameObject GameOver;
    public TextMeshProUGUI keyText;
    public Sprite frontSprite;
    public Sprite backSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    SpriteRenderer currentSprite;
    Vector2 moving;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        GameOver.SetActive(false);
        keys = 0;
        keyText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moving = new Vector2(horizontal * speed, vertical * speed);
        rb.velocity = moving.normalized * speed;
        if (Input.GetKey(KeyCode.W))
        {
            currentSprite.sprite = frontSprite;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentSprite.sprite = backSprite;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            currentSprite.sprite = leftSprite;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            currentSprite.sprite = rightSprite;
        }
        keyText.text = keys.ToString();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Time.timeScale = 0f;
            GameOver.SetActive(true);
        }
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            //Debug.Log("AAAAAAAAAAAAAAAAA");
            other.gameObject.SetActive(false);
            keys += 1;
        }
    }
}
