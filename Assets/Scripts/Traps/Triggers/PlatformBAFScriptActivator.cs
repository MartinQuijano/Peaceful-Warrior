using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBAFScriptActivator : MonoBehaviour
{
    public PathFollowingAndBack scriptToActivate;

    private void Start()
    {
        scriptToActivate = transform.parent.GetComponent<PathFollowingAndBack>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scriptToActivate.enabled = true;
        }
    }
}
