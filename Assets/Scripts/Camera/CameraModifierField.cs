using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModifierField : MonoBehaviour
{
    public float posX, posY;
    public float deadZoneWidth;
    public CameraHelper cameraHelper;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cameraHelper.SetCamera(posX, posY, deadZoneWidth);
        }
    }

}
