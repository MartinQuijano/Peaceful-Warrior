using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    private static GameController gcInstance;

    public GameObject lifeCounter_UIText;

    public int currentLifes;
    public Vector3 playerRespawnPosition;

    public bool levelEnded;
    public bool isVictoryScreenDisplayed;
    public bool isGameOverScreenDisplayed;

    public GameObject victoryScreen;
    public GameObject gameOverScreen;
    public GameObject canvasRoot;
    public TextMeshProUGUI timeAchievedText;
    public TextMeshProUGUI bestTimeAchievedText;
    public TimerController timerController;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (gcInstance == null)
        {
            gcInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        isVictoryScreenDisplayed = false;
        isGameOverScreenDisplayed = false;
        levelEnded = false;
        currentLifes = 2;
        lifeCounter_UIText.GetComponent<TextMeshProUGUI>().text = "x " + currentLifes;
        playerRespawnPosition = player.respawnPoint.transform.position;
    }

    void Update()
    {
        CheckAndReloadCanvasUI();
        if (isVictoryScreenDisplayed || isGameOverScreenDisplayed)
            return;

        if (levelEnded)
        {
            if (!isVictoryScreenDisplayed)
                FinishLevel();
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            player.transform.position = playerRespawnPosition;
        }

        if (lifeCounter_UIText == null)
        {
            lifeCounter_UIText = GameObject.Find("LifeCounter_UIText");
            lifeCounter_UIText.GetComponent<TextMeshProUGUI>().text = "x " + currentLifes;
        }

        if (player.respawnPoint.transform.position != playerRespawnPosition)
        {
            playerRespawnPosition = player.respawnPoint.transform.position;
        }

        if (!player.IsAlive())
        {
            currentLifes -= 1;
            lifeCounter_UIText.GetComponent<TextMeshProUGUI>().text = "x " + currentLifes;
            if (currentLifes == 0)
            {
                isGameOverScreenDisplayed = true;
                gameOverScreen.gameObject.SetActive(true);
                Time.timeScale = 0f;

                gcInstance = null;
            }
            else
            {
                SceneManager.LoadScene("MilitaryLevel");
            }
        }
    }

    private void FinishLevel()
    {
        isVictoryScreenDisplayed = true;

        timeAchievedText.text = timerController.GetTime();

        victoryScreen.gameObject.SetActive(true);
        Time.timeScale = 0f;

        double bestTimeAchievedSaved = PlayerPrefs.GetFloat("Time_Float", 9999999999999999);

        if (timerController.GetTimeInFloat() < bestTimeAchievedSaved)
        {
            PlayerPrefs.SetString("Level_Military", timerController.GetTime());
            PlayerPrefs.SetFloat("Time_Float", timerController.GetTimeInFloat());
        }
        bestTimeAchievedText.text = "Best " + PlayerPrefs.GetString("Level_Military", "0:00,00");

        PlayerPrefs.SetString("LevelCompleted", "true");

        if (timerController.GetTimeInFloat() < 540000f)
        {
            PlayerPrefs.SetString("GreatTime", "true");
        }

        if (!player.WasDamaged())
        {
            PlayerPrefs.SetString("NoDamageTaken", "true");
        }
    }

    private void CheckAndReloadCanvasUI()
    {
        if (canvasRoot == null)
        {
            canvasRoot = GameObject.Find("Canvas");
            victoryScreen = canvasRoot.transform.Find("VictoryScreen").gameObject;
            gameOverScreen = canvasRoot.transform.Find("GameOverScreen").gameObject;
            timeAchievedText = victoryScreen.transform.Find("Time").GetComponent<TextMeshProUGUI>();
            bestTimeAchievedText = victoryScreen.transform.Find("BestTime").GetComponent<TextMeshProUGUI>();
        }
    }
}
