using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentPosX;
    private float currentPosY;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        currentPosX = transform.position.x;
        currentPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, currentPosY, transform.position.z), ref velocity, speed * Time.deltaTime);


    }

    public void MoveToNewRoom(Transform newRoom)
    {
        currentPosX = newRoom.position.x;
        currentPosY = newRoom.position.y;
    }
}
