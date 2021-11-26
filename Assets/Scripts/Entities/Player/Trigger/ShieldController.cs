using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            transform.parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Destroy(collision.gameObject);
        }
    }
}
