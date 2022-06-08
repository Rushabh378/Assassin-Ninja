using UnityEngine;

namespace PlayerController
{
    public class Run : IControl
    {
        public void enterState(PlayerController controller)
        {

        }
        public void updateState(PlayerController controller)
        {
            // Ninja movement and animation..
            controller.movement();
            
            controller.animator.SetFloat("speed", Mathf.Abs(controller.movement_speed));

            if (controller.movement_speed == 0)
            {
                controller.switchState(controller.idle);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                controller.switchState(controller.crouch);
            };
        }
        public void collisionState(PlayerController controller, Collision2D collision)
        {

        }
        public void triggerState(PlayerController controller, Collider2D collision)
        {

        }
    }
}
