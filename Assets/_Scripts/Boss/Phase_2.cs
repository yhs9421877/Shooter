using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase_2 : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public float distance;
    private GameObject[] cannon;
    private Vector2[] target;
    private Vector2[] originalCannonPosition;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("phase 2");
        cannon = new GameObject[4];
        cannon[0] = GameObject.Find("Boss_subCannon (1)");
        cannon[1] = GameObject.Find("Boss_subCannon (2)");
        cannon[2] = GameObject.Find("Boss_subCannon (3)");
        cannon[3] = GameObject.Find("Boss_subCannon (4)");

        target = new Vector2[4];
        originalCannonPosition = new Vector2[4];
        originalCannonPosition[0] = cannon[0].transform.position;
        originalCannonPosition[1] = cannon[1].transform.position;
        originalCannonPosition[2] = cannon[2].transform.position;
        originalCannonPosition[3] = cannon[3].transform.position;

        for(int i=0; i<4; i++){
            switch(i)
            {
                case 0:
                    target[0] = new Vector2(
                        animator.transform.position.x - distance,animator.transform.position.y + distance);
                    break;
                case 1:
                    target[1] = new Vector2(
                        animator.transform.position.x + distance,animator.transform.position.y + distance);
                    break;
                case 2:
                    target[2] = new Vector2(
                        animator.transform.position.x + distance,animator.transform.position.y - distance);
                    break;
                case 3:
                    target[3] = new Vector2(
                        animator.transform.position.x - distance,animator.transform.position.y - distance);
                    break;
            }
            // Debug.Log(target[i]);
            // float[] dirX = new float[4]{-distance,distance,-distance,distance};
            // float[] dirY = new float[4]{distance,distance,-distance,-distance};
            // for(int ii=0; ii<4; ii++){
            //      cannon[ii].transform.position = new Vector2(
            //    cannon[ii].transform.position.x + dirX[ii],
            //    cannon[ii].transform.position.y + dirY[ii]);
            // }
            // int rand = UnityEngine.Random.Range(0,2);
            // if(rand==0){
            //     animator.SetTrigger("Phase2_Spell1");
            // }else animator.SetTrigger("Phase2_Spell2");
            animator.SetTrigger("Phase2_Spell2");
            
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    // override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //    for(int i=0; i<4; i++){
    //         cannon[i].transform.position = Vector2.Lerp(cannon[i].transform.position,target[i],0.05f);
    //    }
    // }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
       
    // }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
