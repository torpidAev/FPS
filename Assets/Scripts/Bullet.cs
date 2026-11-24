using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damageValue = 50f;
    public bool destroyOnHit = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damageValue);
            if (destroyOnHit)
                Destroy(gameObject);
        }
        else if (other.CompareTag("Untagged"))
        {
            Destroy(gameObject);
        }
    }
}