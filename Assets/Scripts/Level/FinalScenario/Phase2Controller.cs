using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2Controller : PhaseController
{

    List<float> posiblePositions = new List<float>();
    List<float> toRestorePositions = new List<float>();

    private bool shouldFire;

    public CannonFinalSceneController[] rightCannons;

    public bool active = false;

    void Start()
    {
        posiblePositions.Add(0);
        posiblePositions.Add(1);
        posiblePositions.Add(2);
        posiblePositions.Add(3);

        shouldFire = true;
        remainingRounds = 8;
    }

    void Update()
    {
        if (!active)
            return;

        if (shouldFire && (remainingRounds > 0))
        {
            shouldFire = false;
            remainingRounds -= 1;

            if (toRestorePositions.Count == 2)
            {
                float toRestore = toRestorePositions[0];
                posiblePositions.Add(toRestore);
                toRestorePositions.RemoveAt(0);
            }

            int index = UnityEngine.Random.Range(0, posiblePositions.Count);
            float notToFirePosition = posiblePositions[index];
            toRestorePositions.Add(notToFirePosition);
            posiblePositions.RemoveAt(index);


            for (int i = 0; i < 4; i++)
            {
                if (i != notToFirePosition)
                {
                    rightCannons[(i*4)].ActivateShootAnimation(true);
                    rightCannons[(i*4)+1].ActivateShootAnimation(true);
                    rightCannons[(i*4)+2].ActivateShootAnimation(true);
                    rightCannons[(i*4)+3].ActivateShootAnimation(true);
                    if(i == 3)
                    {
                        rightCannons[16].ActivateShootAnimation(true);
                        rightCannons[17].ActivateShootAnimation(true);
                    }
                }
            }

            StartCoroutine(WaitAndActivateCannons());
        }
    }

    IEnumerator WaitAndActivateCannons()
    {
        yield return new WaitForSeconds(7f);
        shouldFire = true;
    }
}
