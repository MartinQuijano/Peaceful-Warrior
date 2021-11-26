using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{

    public Sprite[] healthSprites;
    public PlayerController player;

    private Image myImage;

    // Start is called before the first frame update
    void Start()
    {
        myImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        int indexOfHealth = player.GetHealth();
        if(player.IsAlive())
            myImage.sprite = healthSprites[indexOfHealth];
    }
}
