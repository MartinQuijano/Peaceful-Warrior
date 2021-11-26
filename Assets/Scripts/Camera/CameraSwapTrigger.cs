using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwapTrigger : MonoBehaviour
{
    public CameraSwitcher cs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cs.ChangeCamera();
        }
    }
}
