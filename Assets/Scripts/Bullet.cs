using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(50);
        }
        if (other.gameObject.CompareTag("Untagged"))
        {
            Destroy(gameObject);
        }
    
    }
}
