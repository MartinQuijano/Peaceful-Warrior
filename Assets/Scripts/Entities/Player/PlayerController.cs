using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform feetPos;
    public LayerMask whatIsGround;
    public Animator animator;
    private SpriteRenderer playerSprite;
    public Sprite stunSprite;
    public GameObject respawnPoint;
    public PlayerInput input;

    public float moveSpeed = 5f;
    public float jumpSpeed = 15f;

    private bool inmuneActive;
    public float inmuneDuration;
    private float inmuneCounter = 0f;
    public float stunDuration;

    public float checkRadius;

    public bool isOnTheGround;
    public bool isJumping;
    public bool isLookingUp;
    public bool isBlocking;

    public bool canMove = true;

    public int health;
    public int max_health;

    public AudioSource audioSource;

    public AudioClip jumpSFX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        inmuneActive = false;
        isJumping = false;
        max_health = health;
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (inmuneActive)
        {
            if (inmuneCounter > inmuneDuration * .99f)
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0.1f);
            else if (inmuneCounter > inmuneDuration * .82f)
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            else if (inmuneCounter > inmuneDuration * .66f)
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0.1f);
            else if (inmuneCounter > inmuneDuration * .49f)
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            else if (inmuneCounter > inmuneDuration * .33f)
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0.1f);
            else if (inmuneCounter > inmuneDuration * .16f)
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            else if (inmuneCounter > 0f)
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0.1f);
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                inmuneActive = false;
            }
            inmuneCounter -= Time.deltaTime;
        }

        if (input.horizontal > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
        else if (input.horizontal < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
    }

    void FixedUpdate()
    {
        
        PhysicsCheck();
        StateCheck();
        Animations();
        Movement();
    }

    void PhysicsCheck()
    {
        isOnTheGround = false;

        isOnTheGround = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isOnTheGround)
            isJumping = false;
    }

    void StateCheck()
    {
        if (isOnTheGround && input.raiseShieldPressed)
        {
            isBlocking = true;
            canMove = false;
            rb.velocity = Vector2.zero;
        }
        else if (!input.raiseShieldHeld && isBlocking)
        {
            isBlocking = false;
            canMove = true;
        }

        if (isOnTheGround && input.upPressed)
        {
            isLookingUp = true;
        }
        else if (!input.upHeld && isLookingUp)
        {
            isLookingUp = false;
        }
    }

    void Movement()
    {
        if (!canMove)
            return;

        rb.velocity = new Vector2(input.horizontal * moveSpeed, rb.velocity.y);

        if (input.jumpPressed && !isJumping && isOnTheGround)
        {
            audioSource.PlayOneShot(jumpSFX, 0.7f);
            isOnTheGround = false;
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

    }

    void Animations()
    {
        if (isOnTheGround)
        {
            animator.SetBool("IsJumping", false);
        }

        animator.SetFloat("Speed", Mathf.Abs(input.horizontal));
        animator.SetBool("IsJumping", isJumping);

        if (isBlocking)
            animator.SetBool("IsBlocking", true);
        else
            animator.SetBool("IsBlocking", false);

        if (isLookingUp)
            animator.SetBool("IsLookingUp", true);
        else
            animator.SetBool("IsLookingUp", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
            this.transform.parent = collision.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
            this.transform.parent = null;
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        inmuneActive = true;
        inmuneCounter = inmuneDuration;

        Debug.Log("Remaining health: " + health);
    }

    public void GetStuned()
    {
        input.horizontal = 0;
        rb.velocity = Vector2.zero;
        StartCoroutine(Stun());
    }

    IEnumerator Stun()
    {
        isJumping = false;
        canMove = false;
        playerSprite.sprite = stunSprite;
        animator.SetBool("CanMove", false);
        animator.SetBool("IsJumping", false);
        yield return new WaitForSeconds(stunDuration);
        canMove = true;
        animator.SetBool("CanMove", true);
    }

    public bool IsInmune()
    {
        return inmuneActive;
    }

    public int GetHealth()
    {
        return health;
    }

    public bool IsAlive()
    {
        return health > 0;
    }

}
