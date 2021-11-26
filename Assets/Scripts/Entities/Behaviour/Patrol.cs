using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float moveSpeed;
    public float groundDistance;
    public float wallDistance;

    private float dirX = -1;
    private Rigidbody2D rb;

    public Transform groundDetection;
    public Transform wallDetection;
    public LayerMask layerToCollide;

    public Animator animator;
    private bool isAboutToExplode;
    public GameObject explosion;

    public GameObject explosionSoundHolder;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isAboutToExplode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAboutToExplode)
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            if (dirX > 0)
                transform.eulerAngles = new Vector3(0, 180, 0);
            else if (dirX < 0)
                transform.eulerAngles = new Vector3(0, 0, 0);

            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, groundDistance, layerToCollide);
            RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, new Vector2(dirX, 0), wallDistance, layerToCollide);
            if (wallInfo || !groundInfo)
            {
                dirX *= -1;
            }
        }
    }

    public void Activate()
    {
        isAboutToExplode = true;
        animator.SetBool("IsAboutToExplode", true);
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Instantiate(explosionSoundHolder, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
