using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell1Script : StateMachineBehaviour
{
    [SerializeField]
    GameObject spell1;
    //[SerializeField]
    //Transform staffRing;
    [SerializeField]
    float timer, timeToFire;
    bool fired = false;
    Quaternion direction;
    [SerializeField]
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if(timer > timeToFire && !fired)
        {
            fired = true;
            GameObject firer = GameObject.FindGameObjectWithTag("Ring");
            Instantiate(spell1, firer.transform.position, Quaternion.identity);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        timer = 0;
        fired = false;
    }
}
