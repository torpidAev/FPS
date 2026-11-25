using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class WeaponFire : MonoBehaviour
{
    [SerializeField] private Transform FirePoint;
    [SerializeField] private float ShootForce;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private float FireRate = 0.5f;
    [SerializeField] private float ShootCooldown = 0.5f;
    [SerializeField] private bool HoldToShoot = false;

    private float NextFireTime = 0f;

    private InputAction shootAction;

    private void Start()
    {
        shootAction = InputSystem.actions.FindAction("Attack");
        shootAction.started += OnAttackButtonPressed;
    }

    private void Update()
    {
        if (HoldToShoot && shootAction != null && shootAction.IsPressed())
        {
            Shoot();
        }
    }

    private void OnAttackButtonPressed(InputAction.CallbackContext context)
    {
        if (!HoldToShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Time.time < NextFireTime)
            return;

        NextFireTime = Time.time + ShootCooldown + FireRate;

        GameObject newBullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);

        if (newBullet.TryGetComponent(out Rigidbody rb))
        {
            rb.AddForce(ShootForce * FirePoint.forward * Time.fixedDeltaTime, ForceMode.Impulse);
        }
    }

    private void OnDestroy()
    {
        if (shootAction != null)
            shootAction.started -= OnAttackButtonPressed;
    }
}