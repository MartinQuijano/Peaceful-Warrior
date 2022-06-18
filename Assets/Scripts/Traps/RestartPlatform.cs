using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPlatform : MonoBehaviour
{
    public GameObject platformToRestar;

    public void RestartPlatformPosition(){
        if(platformToRestar.GetComponent<PathFollowingAndBack>().enabled == true)
            platformToRestar.GetComponent<PathFollowingAndBack>().Restart();
    }

}
