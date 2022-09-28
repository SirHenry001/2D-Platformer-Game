using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //VARIABLE FOR CAMERA TARGET
    public Transform target;

    //VARIABLE FOR CAMERA POSITION VALUES
    public Vector3 movement;
    public float cameraOffsetY = 3;

    //VARIABLES FOR CAMERA SPEED
    public float cameraSpeed;
    public float cameraSpeedY;

    //VARIABLES FOR CAMERA MOVEMENT LIMITATION
    public float minY;
    public float maxY;
    public float minX;
    public float maxX;

    //VARIABLE FOR SCRIPT
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        //GET ACCESS TO PLAYERCONTROLLER SCRIPT
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //LIMIT CAMERA MOVEMENT FROM minX TO maxX
        //LIMIT CAMERA MOVEMENT FROM minY TO maxY
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY));
    }
    private void FixedUpdate()
    {
        // X AXIS CAMERA MOVEMENT
        movement = transform.position;
        //x axis camera follow
        movement.x = Mathf.Lerp(movement.x, target.position.x, cameraSpeed * Time.deltaTime);

        // Y AXIS CAMERA MOVEMENT
        if (target.position.y <= transform.position.y - cameraOffsetY)
        {
            //camera follow when player fall    
            movement.y = Mathf.Lerp(movement.y, target.position.y, cameraSpeedY * Time.deltaTime);

        }

        /*
        else
        {
            //platfrom snap when player hits the ground     
            movement.y = Mathf.Lerp(movement.y, playerController.storedY + cameraOffsetY, cameraSpeedY * Time.deltaTime);
            
        }
        */


        //tell camera to move
        transform.position = movement;
    }
}
