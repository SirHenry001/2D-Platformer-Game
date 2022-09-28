using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    //VARIABLES FOR SCORE
    public int score;
    public int hiScore;

    //VARIABLE FOR TIMER 
    public int timer;
    public float intervalTimer;

    //VARIABLES FOR TEXT INGAME
    public TextMeshProUGUI timerText;
    public GameObject scoreText;

    //VARIABLES FOR UI AFTER LEVEL CLEAR & DEATH
    public GameObject levelClearedText;
    public GameObject timeOutText;
    public GameObject deathText;
    public GameObject scoreEndText;
    public GameObject recordText;
    public GameObject retryEndButton;
    public GameObject backEndButton;

    //VARIABLES FOR BOOLEANS
    public bool gameEnd = false;

    public PlayerController playerController;



    // Start is called before the first frame update
    void Start()
    {
        hiScore = PlayerPrefs.GetInt("HiScore");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        timerText.GetComponent<TextMeshProUGUI>().text = timer.ToString();

        //if timer hits zero = then gameEnd goes true and EndGame activates
        if (!gameEnd)
        {
            intervalTimer += Time.deltaTime;
            
            if(intervalTimer >= 1)
            {
                timer -= 1;
                intervalTimer = 0;
            }

            if(timer <= 0)
            {
                //player is dead beacuse timer is zero
                TimeOut();
            }
        }
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString(); // GameObject scoreText display in unity updates when score rises
        scoreEndText.GetComponent<TextMeshProUGUI>().text = score.ToString(); 



        /*
        these are needed in the title screen
        hiScore = PlayerPrefs.GetInt("HiScoreText");
        hiScoreText.GetComponent<Text>().text = "HiSCORE:" + hiScore.ToString();
        */
    }

    public IEnumerator ScoreScreen()
    {
        playerController.myRigidbody.velocity = Vector2.zero;
        playerController.enabled = false;

        levelClearedText.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        scoreEndText.SetActive(true);
        yield return new WaitForSeconds(0.2f);

        if (score > hiScore)
        {
            recordText.SetActive(true);

            if (score > hiScore)
            {
                hiScore = score; // if score tops the recenbt hiscore, it becomes new hiscore
                PlayerPrefs.SetInt("HiScore", hiScore); // set hiscore in memory which is int hiscore
                PlayerPrefs.Save(); // save the information which is found by the name "hiScore" everywhere

            }
        }

        retryEndButton.SetActive(true);
        backEndButton.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 0;


    }

    public void TimeOut()// player is dead with time out
    {
        Time.timeScale = 0;
        gameEnd = true;
        timeOutText.SetActive(true);
        backEndButton.SetActive(true);
        retryEndButton.SetActive(true);
    }
    public void DeathGame()// player is dead with health is 0
    {
        Time.timeScale = 0;
        gameEnd = true;
        deathText.SetActive(true);
        backEndButton.SetActive(true);
        retryEndButton.SetActive(true);
    }
}
