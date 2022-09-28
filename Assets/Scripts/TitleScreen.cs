using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleScreen : MonoBehaviour
{
    //VARIABLE FOR HISCORE
    public int hiScore;

    //VARIABLE FOR TEXTS
    public GameObject hiScoreText;
    public GameObject hiScoreHdText;
    public GameObject logoText1;
    public GameObject logoText2;
    public GameObject logoText3;
    public GameObject logoText4;

    public GameObject arrowsText;
    public GameObject spacebarText;
    public GameObject pointsText;
    public GameObject energyText;
    public GameObject enemyText;

    //VARIABLE FOR BUTTONS
    public GameObject startButton;
    public GameObject optionsButton;
    public GameObject backButton;
    public GameObject quitButton;

    //Variable for Images
    public Image bgBeginImage;
    public GameObject anykeyText;

    public GameObject point1Image;
    public GameObject point2Image;
    public GameObject point3Image;
    public GameObject energyImage;
    public GameObject enemyImage;

    //Variable for booleans
    public bool menuActive = false;

    // Start is called before the first frame update
    void Start()
    {
        // GET HIGH SCORE IN THE TITLE SCREEN FROM PLAYERPREFS
        hiScore = PlayerPrefs.GetInt("HiScore");
        hiScoreText.GetComponent<TextMeshProUGUI>().text = hiScore.ToString();
        // GET HIGH SCORE IN THE TITLE SCREEN FROM PLAYERPREFS
        //hiScoreText.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("hiScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey && menuActive == false)
        {
            startButton.SetActive(true);
            optionsButton.SetActive(true);
            quitButton.SetActive(true);
            hiScoreHdText.SetActive(true);
            hiScoreText.SetActive(true);
            logoText3.SetActive(true);
            logoText4.SetActive(true);

            bgBeginImage.gameObject.SetActive(false);
            anykeyText.SetActive(false);
            logoText1.SetActive(false);
            logoText2.SetActive(false);

            menuActive = true;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }

    public void Options()
    {
        startButton.SetActive(false);
        optionsButton.SetActive(false);
        backButton.SetActive(true);
        quitButton.SetActive(false);

        hiScoreHdText.SetActive(false);
        hiScoreText.SetActive(false);
        logoText3.SetActive(false);
        logoText4.SetActive(false);

        arrowsText.SetActive(true);
        spacebarText.SetActive(true);
        pointsText.SetActive(true);
        energyText.SetActive(true);
        enemyText.SetActive(true);

        point1Image.gameObject.SetActive(true);
        point2Image.gameObject.SetActive(true);
        point3Image.gameObject.SetActive(true);
        energyImage.gameObject.SetActive(true);
        enemyImage.gameObject.SetActive(true);

    }

    public void Back()
    {
        startButton.SetActive(true);
        optionsButton.SetActive(true);
        backButton.SetActive(false);
        quitButton.SetActive(true);

        hiScoreHdText.SetActive(true);
        hiScoreText.SetActive(true);
        logoText3.SetActive(true);
        logoText4.SetActive(true);

        arrowsText.SetActive(false);
        spacebarText.SetActive(false);
        pointsText.SetActive(false);
        energyText.SetActive(false);
        enemyText.SetActive(false);

        point1Image.gameObject.SetActive(false);
        point2Image.gameObject.SetActive(false);
        point3Image.gameObject.SetActive(false);
        energyImage.gameObject.SetActive(false);
        enemyImage.gameObject.SetActive(false);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
