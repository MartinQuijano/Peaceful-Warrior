using System.Collections;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    public Animator animator;
    public GameObject explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DestructibleFloor"))
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
        yield return new WaitForSeconds(4f);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
