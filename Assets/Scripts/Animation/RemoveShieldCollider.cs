using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveShieldCollider : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform shieldTransform = animator.gameObject.transform.Find("Shield");
        shieldTransform.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

}
