using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public Sprite openChest;
    public PlayerMove playerScript;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMove>())
        {
            if (playerScript.keys > 0)
            {
                GetComponent<SpriteRenderer>().sprite = openChest;
                playerScript.keys -= 1;
                ChestOpenReward();
            }
        }
    }

    void ChestOpenReward()
    {

    }
}
