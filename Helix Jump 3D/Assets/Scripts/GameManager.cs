using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    

    public static bool gameOver;

    public static bool levelCompleted;
    
    public static bool isGameActived;
    
    public static bool Mute = false;

    public GameObject gameOverPanel;

    public GameObject levelCompletedPanel;

    public GameObject gamePlayPanel;

    public GameObject startMenuPanel;

    public static int currentLevelIndex;

    public TextMeshProUGUI currentLevelText;

    public TextMeshProUGUI nextLevelText;

    public static int numberOfPassedRings;

    public Slider gameProgressSlider;

    public GameObject startButton;

    public GameObject BackButton;

    public GameObject homeButton;

    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        startMenuPanel.SetActive(true);

        Time.timeScale = 0;

        numberOfPassedRings = 1;

        isGameActived = gameOver = false;

        levelCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        currentLevelText.text = currentLevelIndex.ToString();

        nextLevelText.text = (currentLevelIndex + 1).ToString();

        int progress = numberOfPassedRings * 100 / FindObjectOfType<HelixManager>().numberOfRings;

        gameProgressSlider.value = progress;

        if(Input.GetMouseButtonDown(0) && !isGameActived)
        {
            

            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            

            isGameActived = true;

            

            gamePlayPanel.SetActive(true);

            startMenuPanel.SetActive(true);
        }


        if (gameOver)
        {
            Time.timeScale = 0;

            gameOverPanel.SetActive(true);

            startMenuPanel.SetActive(true);

            if (Input.GetMouseButtonDown(1))
            {
                
                SceneManager.LoadScene("Level");

            }
        }

        if (levelCompleted)
        {
            Time.timeScale = 0;

            levelCompletedPanel.SetActive(true);

            if (Input.GetMouseButtonDown(1))
            {

                PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);

                SceneManager.LoadScene("Level");
            }
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1;

        startButton.SetActive(false);

        startMenuPanel.SetActive(false);
    }

    public void backButton()
    {
        Time.timeScale = 1;

        startMenuPanel.SetActive(false);

        homeButton.SetActive(false);
    }

    public void HomeButton()
    {
        Time.timeScale = 0;

        startMenuPanel.SetActive(true);
    }
}
