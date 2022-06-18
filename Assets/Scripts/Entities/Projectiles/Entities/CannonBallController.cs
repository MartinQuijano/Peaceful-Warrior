using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour
{
    public float speed;
    public int directionX;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(directionX * speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platform") || collision.gameObject.CompareTag("Cannon_finalLevel"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(int dirX)
    {
        directionX = dirX;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

}
