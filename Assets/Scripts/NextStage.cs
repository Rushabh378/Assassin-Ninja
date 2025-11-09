using UnityEngine;

public class NextStage : MonoBehaviour
{
    public CanvasRenderer panel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController.PlayerController>() != null)
            panel.gameObject.SetActive(true);
    }
}
