using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnExit : StateMachineBehaviour
{
    public GameObject explosion;
    public GameObject explosionSoundHolder;

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Instantiate(explosion, animator.gameObject.transform.position, Quaternion.identity);
        //Instantiate(explosionSoundHolder, animator.gameObject.transform.position, Quaternion.identity);
        Destroy(animator.gameObject);
    }

}
