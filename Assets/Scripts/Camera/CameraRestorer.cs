using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRestorer : MonoBehaviour
{
    public CameraHelper cameraHelper;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            cameraHelper.RestoreCamera();
    }
}
