using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour
{
    public GameObject pauseText;

    public GameObject resumeButton;
    public GameObject retryButton;
    public GameObject backButton;

    public bool gameActive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameActive == true)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void StartLevel1()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseText.SetActive(false);
        resumeButton.SetActive(false);
        retryButton.SetActive(false);
        backButton.SetActive(false);
    }

    public void Pause()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseText.SetActive(true);
            resumeButton.SetActive(true);
            retryButton.SetActive(true);
            backButton.SetActive(true);
        }

        else
        {
            Time.timeScale = 1;
            pauseText.SetActive(false);
            resumeButton.SetActive(false);
            retryButton.SetActive(false);
            backButton.SetActive(false);
        }
    }
}
