using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    private bool canShoot;
    public GameObject bullet;
    public int shootDirection;
    public float reloadTime;

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
            audioSource.PlayOneShot(shootSFX, 1);
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
    }

    private void Shoot()
    {
        GameObject b = Instantiate(bullet, new Vector2(transform.position.x + (shootDirection * 0.5f), transform.position.y - (0.5f)), Quaternion.identity);
        b.GetComponent<BulletController>().SetDirection(shootDirection);
    }
}
