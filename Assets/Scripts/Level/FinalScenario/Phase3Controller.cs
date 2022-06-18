using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase3Controller : PhaseController
{
    public GameObject explosiveSensor;
    public GameObject[] spawners;
    private bool shouldSpawn;

    List<float> posiblePositions = new List<float>();
    List<float> toRestorePositions = new List<float>();

    public GameObject explosionSoundHolder;

    // Start is called before the first frame update
    void Start()
    {
        posiblePositions.Add(0);
        posiblePositions.Add(1);
        posiblePositions.Add(2);
        posiblePositions.Add(3);
        posiblePositions.Add(4);
        posiblePositions.Add(5);
        posiblePositions.Add(6);
        posiblePositions.Add(7);
        posiblePositions.Add(8);
        posiblePositions.Add(9);
        posiblePositions.Add(10);
        posiblePositions.Add(11);

        shouldSpawn = true;
        remainingRounds = 8;

    }

    // Update is called once per frame
    void Update()
    {
        if (shouldSpawn && (remainingRounds > 0))
        {
            shouldSpawn = false;
            remainingRounds -= 1;

            if (toRestorePositions.Count == 2)
            {
                float toRestore = toRestorePositions[0];
                posiblePositions.Add(toRestore);
                toRestorePositions.RemoveAt(0);
            }

            int index = UnityEngine.Random.Range(0, posiblePositions.Count);
            float notToSpawnPosition = posiblePositions[index];
            toRestorePositions.Add(notToSpawnPosition);
            posiblePositions.RemoveAt(index);


            for (int i = 0; i < 12; i++)
            {
                if (i != notToSpawnPosition)
                {
                    Instantiate(explosiveSensor, spawners[i].transform.position, Quaternion.identity);
                }
            }

            StartCoroutine(WaitAndActivateSpawner());
        }
    }

    IEnumerator WaitAndActivateSpawner()
    {
        yield return new WaitForSeconds(4f);
        Instantiate(explosionSoundHolder, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        shouldSpawn = true;
    }
}
