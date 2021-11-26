using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOnExit : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<CannonFinalSceneController>().Shoot();
        animator.gameObject.GetComponent<CannonFinalSceneController>().ActivateShootAnimation(false);
    }

}
