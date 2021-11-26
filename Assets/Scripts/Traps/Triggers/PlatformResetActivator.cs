using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformResetActivator : MonoBehaviour
{
    public GameObject platformReset;

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player"))
        {
            platformReset.GetComponent<PlatformReset>().enabled = true;
        }
    }
}
