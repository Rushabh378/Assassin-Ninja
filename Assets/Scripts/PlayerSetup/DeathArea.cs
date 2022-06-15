using UnityEngine;
public class DeathArea : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnArea;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.position = spawnArea.transform.position;
        }
    }
}
