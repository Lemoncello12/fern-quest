using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour
{
    DealDamage enemy;
    public float strength;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rotate(float angle)
    {
        
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
