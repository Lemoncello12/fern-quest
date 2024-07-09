using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Sprite openDoor;
    public PlayerMove playerScript;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMove>())
        {
            if (playerScript.keys > 0)
            {
                GetComponent<SpriteRenderer>().sprite = openDoor;
                playerScript.keys -= 1;
                GetComponent<BoxCollider2D>().enabled = false;

            }
        }
    }
}
