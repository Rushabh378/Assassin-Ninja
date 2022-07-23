 using UnityEngine;

namespace EnemySetup
{
    public class bandit_idle : StateMachineBehaviour
    {
        EnemyController enemy;
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            enemy = animator.gameObject.GetComponent<EnemyController>();
            TimerManagement.setTimer(() => backToRunState(animator), countDown: 2f);
        }
        public void backToRunState(Animator animator)
        {
            if (enemy.petroling)
            {
                enemy.flip();
            }
            if (enemy != null )
            {
                if (enemy.facingRight)
                    enemy.direction = 1f;
                else
                    enemy.direction = -1f;
            }
            else
                Debug.Log("enemy controler not found");
            animator.SetInteger("AnimStat", (int)AnimState.run);
        }
        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
        }
        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

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
}
