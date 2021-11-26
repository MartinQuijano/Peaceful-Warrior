using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformReset : MonoBehaviour
{
    public GameObject[] platforms;

    void Start(){

    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (GameObject platform in platforms)
            {
                if(platform.GetComponent<PathFollowingAndBack>().GetIsActive())
                    platform.GetComponent<PathFollowingAndBack>().Restart();
            }
            this.enabled = false;
        }
    }
}
