using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPlatform : MonoBehaviour
{
    public GameObject platformToRestar;

    public void RestartPlatformPosition(){
        
        platformToRestar.GetComponent<PathFollowingAndBack>().Restart();
    }

}
