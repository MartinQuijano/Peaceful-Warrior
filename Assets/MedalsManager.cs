using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedalsManager : MonoBehaviour
{
    public Image medalSlot_levelCompleted;
    public Image medalSlot_greatTime;
    public Image medalSlot_noDamageTaken;

    public Sprite medal_levelCompleted_sprite;
    public Sprite medal_greatTime_sprite;
    public Sprite medal_noDamageTaken_sprite;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetString("LevelCompleted", "false");
        if(PlayerPrefs.GetString("LevelCompleted").Equals("true")){
            medalSlot_levelCompleted.sprite = medal_levelCompleted_sprite;
        }
        if(PlayerPrefs.GetString("GreatTime").Equals("true")){
            medalSlot_greatTime.sprite = medal_greatTime_sprite;
        }
        if(PlayerPrefs.GetString("NoDamageTaken").Equals("true")){
            medalSlot_noDamageTaken.sprite = medal_noDamageTaken_sprite;
        }
    }


}
