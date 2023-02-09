using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using Zenject;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelComplete;
    public static bool mute = false;
    public static bool isGameStarted;

    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;
    public GameObject gamePlayPanel;
    public GameObject startMenuPanel;

    public static int currentLevelIndex;
    public Slider gameProgressSlider;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI coinsValueText;

    public static int numberOfPassedRings;
    public static int score = 0;
    public static int coins;

    [Inject]
    private HelixManager _helixManager;
    [Inject]
    private AudioManager _audioManager;

    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }

    private void Start()
    {
        Time.timeScale = 1;
        numberOfPassedRings = 0;
        highScoreText.text = "Best Score\n" + PlayerPrefs.GetInt("HighScore", 0);
        coinsValueText.text = PlayerPrefs.GetInt("Coins", 0).ToString();
        coins = PlayerPrefs.GetInt("Coins", 0);
        isGameStarted = gameOver = levelComplete = false;
        _audioManager.Init();
    }

    private void Update()
    {
        //Updating UI
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();

        int progress = numberOfPassedRings * 100 / _helixManager.numberOfRings;
        gameProgressSlider.value = progress;

        scoreText.text = score.ToString();

        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isGameStarted)
        if (Input.GetMouseButton(0) && !isGameStarted )
        {
            if(EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) return;
            
            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);
        }
        //Game Over
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                if (score > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", score);
                }
                score = 0;
                SceneManager.LoadScene(0);
                _audioManager.Init();
            }
        }
        //Level Complete
        if (levelComplete)
        {
            levelCompletePanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex+1);
                SceneManager.LoadScene(0);
                _audioManager.Init();
            }
        }
    }

    public void IncreaseMoney()
    {
        coins++;
        PlayerPrefs.SetInt("Coins", coins);
    }
}
