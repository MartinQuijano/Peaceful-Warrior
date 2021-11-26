using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFinalSceneController : CannonController
{
    public Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void ActivateShootAnimation(bool state)
    {
        animator.SetBool("IsAboutToShoot", state);
    }

}
