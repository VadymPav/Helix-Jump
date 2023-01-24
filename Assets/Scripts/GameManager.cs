using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelComplete;

    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;

    public static int currentLevelIndex;
    public Slider gameProgressSlider;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;

    public static int numberOfPassedRings;

    private HelixManager _helixManager;
    private AudioManager _audioManager;

    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start()
    {
        _helixManager = FindObjectOfType<HelixManager>();
        Time.timeScale = 1;
        numberOfPassedRings = 0;
        gameOver = levelComplete = false;
    }

    private void Update()
    {
        //Updating UI
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();

        int progress = numberOfPassedRings * 100 / _helixManager.numberOfRings;
        gameProgressSlider.value = progress;
        //Game Over
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene(0);
            }
        }
        //Level Complete
        if (levelComplete)
        {
            Time.timeScale = 0;
            levelCompletePanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex+1);
                SceneManager.LoadScene(0);
            }
        }
    }
}
