using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScriptActivator : MonoBehaviour
{
    public PathFollowing scriptToActivate;

    private void Start()
    {
        scriptToActivate = transform.parent.GetComponent<PathFollowing>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scriptToActivate.enabled = true;
        }
    }
}
