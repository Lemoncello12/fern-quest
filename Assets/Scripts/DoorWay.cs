using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWay : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;
    [SerializeField] private bool vertical;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (vertical)
            {
                if (collision.transform.position.y < transform.position.y)
                {
                    cam.MoveToNewRoom(nextRoom);
                }
                else
                {
                    cam.MoveToNewRoom(previousRoom);
                }
            }
            else
            {
                if (collision.transform.position.x < transform.position.x)
                {
                    cam.MoveToNewRoom(nextRoom);
                }
                else
                {
                    cam.MoveToNewRoom(previousRoom);
                }
            }
        }
    }
}
