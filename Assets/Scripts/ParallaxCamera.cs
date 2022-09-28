using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxCamera : MonoBehaviour
{
    //SCROLLING SPEED PER AXIS
    public float scrollingSpeedX;
    public float scrollingSpeedY;

    //TARGET FOR CAMERA COMPARED TO SCROLLING
    public Transform target;

    //BOOLEANS
    public bool cameraActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraActive == true)
        {
            transform.position = new Vector2(target.position.x * scrollingSpeedX, transform.position.y * scrollingSpeedY);
        }
        
    }
}
