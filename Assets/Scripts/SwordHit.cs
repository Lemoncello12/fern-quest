using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordHit : MonoBehaviour
{
    DealDamage enemy;
    public float strength;
    public float damageTime = 0.25f;
    public float cooldownTime = 2f;
    float timer;
    bool damageTimer = false;
    bool cooldown = false;
    SpriteRenderer sprite;
    BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damageTimer)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                damageTimer = false;
                endHit();
            }
        }
        if (cooldown)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                cooldown = false;
            }
        }
       if (Input.GetMouseButtonDown(0) && !cooldown)
        {
            startHit();
        }
    }
    
    void startHit()
    {
        timer = damageTime;
        damageTimer = true;
        sprite.enabled = true;
        collider.enabled = true;
    }

    void endHit()
    {
        sprite.enabled = false;
        collider.enabled = false;
        timer = cooldownTime;
        cooldown = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DealDamage>())
        {
            enemy = collision.gameObject.GetComponent<DealDamage>();
            if (enemy.takesDamage == true)
            {
                enemy.TakeDamage(strength);
            }
        }
    }
}
