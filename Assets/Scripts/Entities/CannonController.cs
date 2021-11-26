using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    protected bool canShoot;
    public GameObject cannonBall;
    public int shootDirection;
    public float reloadTime;
    public float cannonBallSpeed;

    public AudioSource audioSource;

    public AudioClip shootSFX;

    void Start()
    {
        canShoot = true;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (canShoot)
        {
            Shoot();
            canShoot = false;
            audioSource.PlayOneShot(shootSFX, 0.9f);
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
    }

    public void Shoot()
    {  
        GameObject cb = Instantiate(cannonBall, new Vector2(transform.position.x + (shootDirection * 0.7f), transform.position.y), Quaternion.identity);
        cb.GetComponent<CannonBallController>().SetDirection(shootDirection);
        cb.GetComponent<CannonBallController>().SetSpeed(cannonBallSpeed);
    }
}
