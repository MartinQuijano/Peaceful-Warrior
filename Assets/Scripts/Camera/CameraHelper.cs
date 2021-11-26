using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHelper : MonoBehaviour
{
    public CinemachineVirtualCamera cvc;
    public float originalScreenX;
    public float originalScreenY;

    void Start()
    {
        originalScreenX = cvc.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX;
        originalScreenY = cvc.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY;

    }

    public void SetCamera(float valueX, float valueY, float deadZoneWidth)
    {
        cvc.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = valueX;
        cvc.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = valueY;
        cvc.GetCinemachineComponent<CinemachineFramingTransposer>().m_DeadZoneWidth = deadZoneWidth;
        
    }
    
    public void SetCameraWithSoftZone(float valueX, float valueY, float deadZoneWidth)
    {
        cvc.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = valueX;
        cvc.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = valueY;
        cvc.GetCinemachineComponent<CinemachineFramingTransposer>().m_DeadZoneWidth = deadZoneWidth;
        cvc.GetCinemachineComponent<CinemachineFramingTransposer>().m_SoftZoneWidth = deadZoneWidth;

    }

    public void StopCameraFromFollowingPlayer()
    {
        cvc.m_Follow = null;
    }

    public void CameraFollowObject(GameObject objectToFollow)
    {
        cvc.m_Follow = objectToFollow.transform;
    }

    public void RestoreCamera()
    {
        cvc.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = originalScreenX;
        cvc.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = originalScreenY;
    }

    public void changeCamera(CinemachineVirtualCamera newCamera){
        cvc = newCamera;
    }
}
