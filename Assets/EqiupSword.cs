using UnityEngine;

public class EqiupSword : MonoBehaviour
{
    [SerializeField]
    private RuntimeAnimatorController animatorController;
    private PlayerController.PlayerController controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        controller = collision.gameObject.GetComponent<PlayerController.PlayerController>();
        if(controller != null)
        {
            controller.animator.runtimeAnimatorController = animatorController;
            this.gameObject.SetActive(false);
        }
    }
}
