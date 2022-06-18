using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGOActivator : MonoBehaviour
{
    public GameObject toActivate;
    public float secondToWaitBeforeActivate;

    public GameObject alamarSoundHolder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(WaitAndActivate());
        }
    }

    IEnumerator WaitAndActivate()
    {   
        Instantiate(alamarSoundHolder, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(secondToWaitBeforeActivate);
        toActivate.SetActive(true);
        Destroy(gameObject);   
    }
}
