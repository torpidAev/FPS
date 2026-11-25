using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damageValue = 50f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damageValue);
        }
    }
    
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
}
