using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class WeaponFire : MonoBehaviour
{
    [SerializeField] private Transform FirePoint;
    [SerializeField] private float ShootForce;
    [SerializeField] private GameObject BulletPrefab;

    private InputAction shootAction;
    private void Start()
    {
       shootAction = InputSystem.actions.FindAction("Attack"); 
       shootAction.started += OnAttackButtonPressed;
    }

    private void OnAttackButtonPressed(InputAction.CallbackContext context)
    {
        Shoot();
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        if (newBullet.TryGetComponent(out Rigidbody rb))
        {
            rb.AddForce(ShootForce * FirePoint.forward * Time.fixedDeltaTime, ForceMode.Impulse);
        }
    }

    private void OnDestroy()
    {
        shootAction.started -= OnAttackButtonPressed;
    }
    
}
