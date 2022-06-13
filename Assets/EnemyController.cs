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
        public GameObject Detector;
        private float direction = -1f;
        private bool facingRight = false;
        [HideInInspector]
        public bool AleartMode = false;
        private Animator animator;
        private Transform target = null;
        private void Start()
        {
            animator = GetComponent<Animator>();
        }
        private void Update()
        {
            if (direction == 0)
                animator.SetInteger("AnimState", (int)AnimState.idle);
            else
                animator.SetInteger("AnimState", (int)AnimState.run);
        }
        private void FixedUpdate()
        {
            RaycastHit2D hit2D = Physics2D.Raycast(Detector.transform.position, -Detector.transform.right, sightLength);
            if (hit2D)
            {
                Debug.Log("player detect" + hit2D.collider.gameObject.name);
                Debug.DrawRay(Detector.transform.position, -Detector.transform.right, Color.yellow, sightLength);

                if (hit2D.collider.GetComponent<PlayerController.PlayerController>() != null)
                {
                    Debug.DrawRay(Detector.transform.position, -Detector.transform.right, Color.red, sightLength);
                    AleartMode = true;
                    target = hit2D.transform;
                    animator.SetInteger("AnimState", (int)AnimState.run);
                }
                else if(hit2D.collider.CompareTag("flipper") && !AleartMode)
                {
                    flip();
                }
            }
            else
            {
                Debug.DrawRay(Detector.transform.position, -Detector.transform.right, Color.green, sightLength);
                Debug.Log("raycast working");
            }
            if (Input.GetKey(KeyCode.I))
            {
                animator.SetTrigger("Attack");
            }
        }
        public void movement()
        {
            Vector2 position = transform.position;
            position.x += direction * movementSpeed * Time.fixedDeltaTime;
            transform.position = position;
        }
        public void flip()
        {
            direction *= -1f;
            transform.Rotate(0f, 180, 0f);
            facingRight = !facingRight;
        }
        public void followTarget()
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.fixedDeltaTime);

            //fliping enemy towerds player
            if (target.position.x > transform.position.x && !facingRight)
                flip();
            else if (target.position.x < transform.position.x && facingRight)
                flip();
        }

    }
}
