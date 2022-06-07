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
            // taking input for ellen movement and animation..
            controller.movement_speed = Input.GetAxis("Horizontal");
            controller.animator.SetFloat("speed", Mathf.Abs(controller.movement_speed));

            //animating and flippping ellen according to value.
            if (controller.facing_right)
            {
                if (controller.movement_speed < 0)
                {
                    controller.flip();
                }
            }
            else
            {
                if (controller.movement_speed > 0)
                {
                    controller.flip();
                }
            }

            controller.movement();

            if (controller.movement_speed == 0)
            {
                controller.switchState(controller.idle);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                controller.switchState(controller.crouch);
            };
        }
        public void collisionState(PlayerController controller, Collision2D collision)
        {

        }
    }
}
