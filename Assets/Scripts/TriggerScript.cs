using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{

    public ParallaxCamera parallaxCam;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ParallaxFollow")
        {
            parallaxCam.cameraActive = true;
        }

        if (collision.gameObject.tag == "ParallaxReset")
        {
            parallaxCam.cameraActive = false;
        }

        if (collision.gameObject.tag == "Death")
        {
            gameManager.DeathGame();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        parallaxCam = GameObject.Find("BackGround").GetComponent<ParallaxCamera>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
