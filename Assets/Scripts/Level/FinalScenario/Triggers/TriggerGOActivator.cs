using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGOActivator : MonoBehaviour
{
    public GameObject toActivate;
    public float secondToWaitBeforeActivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitAndActivate());
        }
    }

    IEnumerator WaitAndActivate()
    {
        yield return new WaitForSeconds(secondToWaitBeforeActivate);
        toActivate.SetActive(true);
    }
}
