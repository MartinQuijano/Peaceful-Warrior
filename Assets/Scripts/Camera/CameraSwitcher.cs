using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera cvc1;
    public CinemachineVirtualCamera cvc2;

    public CameraHelper ch;

    public GameObject player;

    public void ChangeCamera()
    {
        cvc1.enabled = false;
        cvc2.enabled = true;

        ch.changeCamera(cvc2);

        cvc2.m_Follow = player.transform;
    }
}

