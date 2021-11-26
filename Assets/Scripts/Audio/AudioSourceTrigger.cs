using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlaySoundAndDestroy());
    }

    IEnumerator PlaySoundAndDestroy(){

        AudioSource  audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy (gameObject);
    }


}
