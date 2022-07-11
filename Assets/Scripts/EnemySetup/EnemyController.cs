using UnityEngine;

namespace EnemySetup
{
    enum AnimState
    {
        idle,
        combetidle,
        run
    }
    public class EnemyController : MonoBehaviour
    {
        public float sightLength = 2;
        public float movementSpeed = 2f;
        public float unfoloowDistance = 4f;
        public int health = 100;
        public GameObject Detector;
        [HideInInspector]
        public float direction = -1f;
        [HideInInspector]
        public bool facingRight = false;
        [HideInInspector]
        public bool AleartMode = false;
        //private bool onGround = true;
        private Animator animator;
        private Rigidbody2D RB;
        [HideInInspector]
        public Transform target = null;
        private float combetDistance = 2.5f;
        private void Start()
        {
            animator = GetComponent<Animator>();
            RB = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            if (direction == 0)
            {
                if (AleartMode)
                    animator.SetInteger("AnimState", (int)AnimState.combetidle);
                else
                    animator.SetInteger("AnimState", (int)AnimState.idle);
            }
            else
                animator.SetInteger("AnimState", (int)AnimState.run);

            if (Input.GetKey(KeyCode.I))
                jump();
        }
        private void FixedUpdate()
        {
            RaycastHit2D hit2D = Physics2D.Raycast(Detector.transform.position, -Detector.transform.right, sightLength, 1);
            if (hit2D)
            {
                Debug.Log("Enemy detected" + hit2D.collider.gameObject.name);
                Debug.DrawRay(Detector.transform.position, -Detector.transform.right, Color.yellow, sightLength);

                if (hit2D.collider.GetComponent<PlayerController.PlayerController>() != null)
                {
                    Debug.DrawRay(Detector.transform.position, -Detector.transform.right, Color.red, sightLength);
                    AleartMode = true;
                    target = hit2D.transform;
                    animator.SetInteger("AnimState", (int)AnimState.run);
                }
                else if(hit2D.collider.CompareTag("flipper"))
                {
                    if (!AleartMode)
                    {
                        flip();
                    }
                }
            }
            else
            {
                Debug.DrawRay(Detector.transform.position, -Detector.transform.right, Color.green, sightLength);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Ground"))
            {
                //onGround = true;
                animator.SetBool("Jump", false);
            }
                
        }
        /*public void getDamage(float damage)
        {
            if(damage >= health)
            {
                animator.SetTrigger("Damage");
                Debug.Log("Player got Hit!");
            }
        }*/
        public void movement()
        {
            Vector2 position = transform.position;
            position.x += direction * movementSpeed * Time.fixedDeltaTime;
            transform.position = position;
        }
        public void jump()
        {
            RB.AddForce(Vector2.up, ForceMode2D.Impulse);
            //animator.SetBool("Jump", true);
            //onGround = false;
        }
        public void flip()
        {
            direction *= -1f;
            transform.Rotate(0f, 180, 0f);
            facingRight = !facingRight;
        }
        public void followTarget()
        {
            float distance = Vector2.Distance(transform.position, target.position);
            Debug.Log("distance : " + distance);
            if (distance >= unfoloowDistance)
                AleartMode = false;
            if (distance <= combetDistance)
                direction = 0;
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.fixedDeltaTime);
                Debug.Log("following target");

                //fliping enemy towerds player
                if (target.position.x > transform.position.x && !facingRight)
                {
                    direction = 1f;
                    flip();
                }
                else if (target.position.x < transform.position.x && facingRight)
                {
                    direction = -1f;
                    flip();
                }
            }
            
                
        }

    }
}
