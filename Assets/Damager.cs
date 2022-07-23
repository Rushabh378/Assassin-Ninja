using UnityEngine;

public class Damager : MonoBehaviour
{
    private IDamageable damageable;
    private bool canDamage = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        damageable = collision.gameObject.GetComponent<IDamageable>();
        //Debug.Log("front enemy:" + collision.gameObject.name);

        if (damageable != null)
        {
            canDamage = true;
        }
        else
            canDamage = false;
    }
    /*private void OnTriggerStay2D(Collider2D collision)
    { 
        damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            canDamage = true;
        }
        else
            canDamage = false;
    }*/
    public void DoDamage(int damage)
    {
        if (canDamage)
            damageable.getDamage(damage);
    }
}
