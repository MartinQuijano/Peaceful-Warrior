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
    public TextMeshProUGUI timer;
    public TextMeshProUGUI bestTime;

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
        bestTime.text = "Best time: " + PlayerPrefs.GetString("Level_Military", "0:00,00");
        levelEnded = false;
        currentLifes = 2;
        lifeCounter_UIText.GetComponent<TextMeshProUGUI>().text = "x " + currentLifes;
        playerRespawnPosition = player.respawnPoint.transform.position;
    }

    void Update()
    {       
        if (levelEnded)
        {
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

        if(player.respawnPoint.transform.position != playerRespawnPosition)
        {
            playerRespawnPosition = player.respawnPoint.transform.position;
        }

        if (!player.IsAlive())
        {
            currentLifes -= 1;
            lifeCounter_UIText.GetComponent<TextMeshProUGUI>().text = "x " + currentLifes;
            if (currentLifes == 0)
            {
                //de momento asi pero debe activarse el menu que sea necesario para resetear el nivel
                gcInstance = null;
                SceneManager.LoadScene("SampleScene");
                Destroy(this.gameObject);
            }
            else
            {
              //  StartCoroutine(WaitSecondAndRespawnPlayer());
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    private void FinishLevel()
    {
        float currentTime = float.Parse(timer.text);
        float recordTime = float.Parse(bestTime.text);

        if (currentTime < recordTime)
        {
            // Desplegar un texto indicando que se consiguió un nuevo record de tiempo
            Debug.Log("TIEMPO RECORD!");
            PlayerPrefs.SetString("Level_Military", timer.text);
        }
    }
}
