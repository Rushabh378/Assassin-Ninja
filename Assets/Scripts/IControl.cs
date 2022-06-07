using UnityEngine;

namespace PlayerController
{
    public interface IControl
    {
        void enterState(PlayerController controller);
        void updateState(PlayerController controller);
        void collisionState(PlayerController controller, Collision2D collision);
    }
}
