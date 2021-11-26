using UnityEngine;
using TMPro;
using System;

public class TimerController : MonoBehaviour
{
    private static TimerController tcInstance;

    public TextMeshProUGUI TMP_text;

    private TimeSpan timePlaying;
    public bool timerActive;

    private float elapsedTime;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (tcInstance == null)
        {
            tcInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        TMP_text.text = "Time: 0:00.00";
        timerActive = true;
    }

    public void BeginTimer()
    {
        timerActive = true;
        elapsedTime = 0f;
    }
    
    public void EndTimer()
    {
        timerActive = false;
    }

    private void Update()
    {
        if(TMP_text == null)
        {
            TMP_text = GameObject.FindGameObjectWithTag("CurrentTime").GetComponent<TextMeshProUGUI>();
        }

        if (timerActive)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            TMP_text.text = timePlayingStr;
        }
    }
}
