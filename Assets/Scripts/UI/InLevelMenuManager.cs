using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InLevelMenuManager : MonoBehaviour
{
    public GameObject gameController;
    public GameObject timeController;
    public GameObject backgroundMusic;
    public GameObject pauseScreen;
    public bool gamePaused;
    public TextMeshProUGUI bestTimeAchievedText;

    public void Start(){

        gameController = GameObject.Find("GameController");
        timeController = GameObject.Find("TimeController");
        backgroundMusic = GameObject.Find("BackgroundMusic");

        gamePaused = false;
        bestTimeAchievedText.text = "Best " + PlayerPrefs.GetString("Level_Military", "Time: 0:00,00");
    }

    public void OpenScene(int index){
        Destroy(gameController);
        Destroy(timeController);
        Destroy(backgroundMusic);

        Time.timeScale = 1f;

        SceneManager.LoadScene(index);
    }

    public void PauseGame(){     

        gamePaused = true;
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void ResumeGame(){
        gamePaused = false;
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
    }

    public bool isGamePaused(){
        return gamePaused;
    }

}