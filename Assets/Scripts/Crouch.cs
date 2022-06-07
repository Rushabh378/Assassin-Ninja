using UnityEngine;

namespace PlayerController
{
    public class Crouch : IControl
    {
        Vector2 size;
        Vector2 offset;
        public void enterState(PlayerController controller)
        {
            controller.animator.SetBool("crouch", true);
            //controller.capsuleCollider.enabled = false;
            size = controller.capsuleCollider.size;
            offset = controller.capsuleCollider.offset;
            controller.capsuleCollider.size = new Vector2(controller.capsuleCollider.size.x, 1.37f);
            controller.capsuleCollider.offset = new Vector2(controller.capsuleCollider.offset.x, -0.25f);
        }
        public void updateState(PlayerController controller)
        {
            if (Input.GetKeyUp(KeyCode.S))
            {
                controller.animator.SetBool("crouch", false);
                //controller.capsuleCollider.enabled = true;
                controller.capsuleCollider.size = size;
                controller.capsuleCollider.offset = offset;
                controller.idleOrRun();
            }
        }
        public void collisionState(PlayerController controller, Collision2D collision)
        {

        }
    }
}