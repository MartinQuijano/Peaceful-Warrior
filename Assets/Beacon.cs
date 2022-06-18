using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    public bool isActive = false;
    public Sprite activeSprite;

    public AudioSource audioSource;
    public AudioClip activateSFX;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Activate(){
        if(!isActive){
            isActive = true;
            GetComponent<SpriteRenderer>().sprite = activeSprite;
            audioSource.PlayOneShot(activateSFX, 0.25f);
        }
    }
}
