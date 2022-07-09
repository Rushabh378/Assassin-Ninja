using UnityEngine;

public class Damager : MonoBehaviour
{
    public static float damage = 100;
    private static IDamageable damageable;
    private static bool canDamage = false;
    private void OnTriggerStay2D(Collider2D collision)
    { 
        damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            canDamage = true;
        }
        else
            canDamage = false;
    }
    public static void DoDamage()
    {
        if (canDamage)
            damageable.getDamage(damage);
    }
}
