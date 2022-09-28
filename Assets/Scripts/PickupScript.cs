using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupScript : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Point100")
        {
            Destroy(collision.gameObject);
            gameManager.AddScore(100);

        }

        if (collision.gameObject.tag == "Point300")
        {
            Destroy(collision.gameObject);
            gameManager.AddScore(300);

        }

        if (collision.gameObject.tag == "Point500")
        {
            Destroy(collision.gameObject);
            gameManager.AddScore(500);

        }

        if (collision.gameObject.tag == "Health")
        {
            Destroy(collision.gameObject);
            gameManager.timer = 60;
            gameManager.timerText.GetComponent<TextMeshProUGUI>().text = gameManager.timer.ToString();
            playerController.playerHealth = 100;
            playerController.healthImage.fillAmount = playerController.playerHealth * 0.01f;
            gameManager.AddScore(500);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
