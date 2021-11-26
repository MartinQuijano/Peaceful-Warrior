using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorPlayerDetector : MonoBehaviour
{
    public GameObject explosion;
    public Animator animator;

    public GameObject explosionSoundHolder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Activate();
        }
    }

    public void Activate()
    {
        animator.SetBool("IsAboutToExplode", true);
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Instantiate(explosionSoundHolder, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
