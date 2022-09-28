using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{

    public GameManager gameManager;
    public GameMenuScript gameMenuScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(gameManager.ScoreScreen());
            gameMenuScript.gameActive = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameMenuScript = GameObject.Find("Canvas").GetComponent<GameMenuScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
