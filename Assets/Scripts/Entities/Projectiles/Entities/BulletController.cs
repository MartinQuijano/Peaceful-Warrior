using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public int directionX;

    private Rigidbody2D rb;
    public int damage = 1;

    public float secondsToDestroyItself;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Destroy(gameObject, secondsToDestroyItself);
    }

    void Update()
    {
        rb.velocity = new Vector2(directionX * speed, (-1 * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    public void SetDirection(int dirX)
    {
        directionX = dirX;
    }
}
