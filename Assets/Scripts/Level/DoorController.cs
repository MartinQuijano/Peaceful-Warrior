using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool isOpen;
    public Animator animator;
    public float offset;

    public GameObject doorSoundHolder;

    void Start()
    {
        isOpen = false;
        transform.position = new Vector2(transform.position.x, transform.position.y + offset);
    }

    void Update()
    {
        
    }

    public void SetOpen(bool open)
    {
        isOpen = open;
        animator.SetBool("IsOpen", open);
        if(doorSoundHolder != null)
            Instantiate(doorSoundHolder, transform.position, Quaternion.identity);
    }
}
