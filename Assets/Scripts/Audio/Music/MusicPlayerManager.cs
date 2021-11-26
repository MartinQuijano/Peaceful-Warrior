using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerManager : MonoBehaviour
{
    private static MusicPlayerManager instance = null;
    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

}
