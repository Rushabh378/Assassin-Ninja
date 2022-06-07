using UnityEngine;

namespace PlayerController
{
    public class Idle : IControl
    {
        public void enterState(PlayerController controller)
        {

        }
        public void updateState(PlayerController controller)
        {
            controller.movement_speed = Input.GetAxis("Horizontal");
            controller.animator.SetFloat("speed", Mathf.Abs(controller.movement_speed));
            if (controller.movement_speed != 0)
            {
                controller.switchState(controller.run);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                controller.switchState(controller.crouch);
            }
        }
        public void collisionState(PlayerController controller, Collision2D collision)
        {

        }
    }
}