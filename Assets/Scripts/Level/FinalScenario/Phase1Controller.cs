using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase1Controller : PhaseController
{
    public GameObject bomb;
    public GameObject[] spawners;

    List<float> posiblePositions = new List<float>();
    List<float> toRestorePositions = new List<float>();

    private bool shouldSpawn;
    
    void Start()
    {
        posiblePositions.Add(0);
        posiblePositions.Add(1);
        posiblePositions.Add(2);
        posiblePositions.Add(3);
        posiblePositions.Add(4);
        posiblePositions.Add(5);

        shouldSpawn = true;
        remainingRounds = 8;
    }

    void Update()
    {
        if (shouldSpawn && (remainingRounds > 0))
        {
            shouldSpawn = false;
            remainingRounds -= 1;

            if(toRestorePositions.Count == 2)
            {
                float toRestore = toRestorePositions[0];
                posiblePositions.Add(toRestore);
                toRestorePositions.RemoveAt(0);
            }

            int index = UnityEngine.Random.Range(0, posiblePositions.Count);
            float notToSpawnPosition = posiblePositions[index];
            toRestorePositions.Add(notToSpawnPosition);
            posiblePositions.RemoveAt(index);

            
            for (int i = 0; i < 6; i++)
            {
                if (i != notToSpawnPosition)
                {
                    Instantiate(bomb, spawners[i].transform.position, Quaternion.identity);
                }
            }

            StartCoroutine(WaitAndActivateSpawner());
        }
    }

    IEnumerator WaitAndActivateSpawner()
    {
        yield return new WaitForSeconds(6f);
        shouldSpawn = true;
    }

}
