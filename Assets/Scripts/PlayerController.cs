using UnityEngine;

namespace PlayerController
{
    public class PlayerController : MonoBehaviour
    {
        IControl currentState;
        public Idle idle = new Idle();
        public Run run = new Run();
        public Jump jump = new Jump();
        public Crouch crouch = new Crouch();

        [HideInInspector]
        public Animator animator;
        [HideInInspector]
        public Rigidbody2D rb;
        [HideInInspector]
        public CapsuleCollider2D capsuleCollider;

        public float jump_force = 5f;
        [HideInInspector]
        public float movement_speed;
        [HideInInspector]
        public bool bool_jump = false;
        public float speed = 5f;
        public bool facing_right = true;

        // Start is called before the first frame update
        void Start()
        {
            //getting all neccessary components
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            capsuleCollider = GetComponent<CapsuleCollider2D>();

            currentState = idle;
            currentState.enterState(this);

        }

        // Update is called once per frame
        void Update()
        {
            anyToJump();
            currentState.updateState(this);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                //Debug.Log("ellen collided ground");
                animator.SetBool("jump", false);
            }
            currentState.collisionState(this, collision);
        }
        public void movement()
        {
            Vector2 position = transform.position;
            position.x += movement_speed * speed * Time.deltaTime;
            transform.position = position;
        }
        public void switchState(IControl state)
        {
            currentState = state;
            currentState.enterState(this);
        }
        public void idleOrRun()
        {
            if (movement_speed == 0)
            {
                switchState(idle);
            }
            else
            {
                switchState(run);
            }
        }
        public void anyToJump()
        {
            //if player jumps
            if (Input.GetButtonDown("Jump"))
                switchState(jump);
        }
        public void flip()
        {
            transform.Rotate(0f, 180, 0f);
            facing_right = !facing_right;
        }
    }
}
