using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFalling : MonoBehaviour
{
    public CameraHelper chelp;
    public GameObject respawnFromFall;
    public PlayerController player;

    public RestartPlatform restartPlatform;

    public int damageFromFall;

    private void Start()
    {
        damageFromFall = 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            chelp.StopCameraFromFollowingPlayer();
            player.TakeDamage(damageFromFall);
            if(restartPlatform != null){
                restartPlatform.RestartPlatformPosition();
            }
            if (player.IsAlive())
            {
                StartCoroutine(WaitAndRespawnPlayer());
            }
        }
    }

    IEnumerator WaitAndRespawnPlayer()
    {
        yield return new WaitForSeconds(1.5f);
        player.gameObject.transform.position = respawnFromFall.transform.position;
        chelp.CameraFollowObject(player.gameObject);
    }
}
