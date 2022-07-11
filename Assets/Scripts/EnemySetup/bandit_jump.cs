using UnityEngine;
namespace EnemySetup
{
    public class bandit_jump : StateMachineBehaviour
    {
        private EnemyController enemy;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            enemy = animator.GetComponent<EnemyController>();
            enemy.jump();
        }
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            enemy.movement();
        }
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
        }
    }
}
