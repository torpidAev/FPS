using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] Slider healthBar;

    bool isDead = false;
    Collider playerColl;

    void Awake()
    {
        playerColl = GetComponent<Collider>();

        healthBar.maxValue = hitPoints;
        healthBar.value = hitPoints;
    }

    public void TakeDamage(float damageAmount)
    {
        if (isDead) return;

        hitPoints -= damageAmount;

        healthBar.value = hitPoints;
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

            if (playerColl != null)
            {
                playerColl.enabled = false;
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}