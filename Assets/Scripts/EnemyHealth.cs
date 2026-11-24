using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;
    Collider enemyColl;

    public void  TakeDamage(float damageAmount)
    {
        hitPoints -= damageAmount;
    }

    void Awake()
    {
        enemyColl = GetComponent<Collider>();
    }

    public bool IsDead()
    {
        return isDead;
    }

    private void Update()
    {
        if (hitPoints <= 0 && !isDead)
        {
            isDead = true;
            enemyColl.enabled = false;
            Destroy(gameObject);
        }
    }
}