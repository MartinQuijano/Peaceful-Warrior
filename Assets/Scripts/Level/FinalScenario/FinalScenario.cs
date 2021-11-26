using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScenario : MonoBehaviour
{
    public PhaseController[] phases;
    private int actualPhaseIndex;

    public GameObject floorToDestroyWhenPhase2Ends;
    public GameObject[] phase2Objects;

    public bool isChangingPhases;

    public DoorController door;

    void Start()
    {
        actualPhaseIndex = 0;
        EnablePhase(actualPhaseIndex);
        isChangingPhases = false;
    }

    private void Update()
    {
        if (ThereIsAnotherPhase(actualPhaseIndex))
        {
            if (phases[actualPhaseIndex].IsPhaseOver() && !isChangingPhases)
            {
            isChangingPhases = true;
            
            StartCoroutine(WaitTimeBetweenPhases());
            StartCoroutine(WaitTimeToDestroyFloorPhase2());
            Debug.Log("wow");
            }
        }
        else
        {
            if (phases[actualPhaseIndex].IsPhaseOver())
                StartCoroutine(WaitTimeAndOpenDoor());            
        }
    }

    IEnumerator WaitTimeAndOpenDoor()
    {
        yield return new WaitForSeconds(3f);
        door.SetOpen(true);
    }
    private void ChangePhaseToNext()
    {
        DisablePhase(actualPhaseIndex);
        if (ThereIsAnotherPhase(actualPhaseIndex))
        {
            EnablePhase(actualPhaseIndex + 1);
            actualPhaseIndex += 1;
        }
        
        isChangingPhases = false;
    }

    public bool ThereIsAnotherPhase(int index)
    {
        return (index + 1) < phases.Length;
    }

    public void EnablePhase(int index)
    {
        phases[index].enabled = true;
    }

    public void DisablePhase(int index)
    {
        phases[index].enabled = false;
    }

    IEnumerator WaitTimeBetweenPhases()
    {
        yield return new WaitForSeconds(10f);
        ChangePhaseToNext();
    }

    IEnumerator WaitTimeToDestroyFloorPhase2()
    {
        yield return new WaitForSeconds(8f);
        if (actualPhaseIndex == 1)
        {
            ClearPhase2Objects();
        }
    }

    public void ClearPhase2Objects()
    {
        for(int i=0;i < phase2Objects.Length; i++)
        {
            Destroy(phase2Objects[i]);
        }
    }

}
