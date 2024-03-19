using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{


    public float speed = 5f;
    public Rigidbody2D rb;
    public int currentHealth = 0;
    public int maxHealth = 20;
    Vector2 moving;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moving = new Vector2(horizontal * speed, vertical * speed);
        rb.velocity = moving.normalized * speed;

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            OnDeath();
        }
    }

    void OnDeath()
    {
        Time.timeScale = 0f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
