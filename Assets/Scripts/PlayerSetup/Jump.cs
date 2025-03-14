﻿using UnityEngine;

namespace PlayerController
{
    public class Jump : IControl
    {

        public void enterState(PlayerController controller)
        {
            controller.rb.velocity = Vector2.up * controller.jump_force;
            controller.animator.SetBool("jump", true);
            controller.isJumping = true;
        }
        public void updateState(PlayerController controller)
        {
            controller.movement();
        }
        public void collisionState(PlayerController controller, Collision2D collision)
        {
            
        }
        public void triggerState(PlayerController controller, Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                controller.idleOrRun();
            }
        }
    }
}