using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponInventory : MonoBehaviour
{
    public GameObject[] weapons;

    private int currentWeaponIndex = 0;

    void Start()
    {
        EquipWeapon(currentWeaponIndex);
    }

    void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.qKey.wasPressedThisFrame)
        {
            Debug.Log("Q PRESSED - Frame: " + Time.frameCount);

            NextWeapon();
        }
    }

    void EquipWeapon(int index)
    {
        if (index < 0 || index >= weapons.Length)
            return;

        // Disable all weapons
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

        // Enable selected weapon
        weapons[index].SetActive(true);

        currentWeaponIndex = index;

        Debug.Log("Equipped: " + weapons[index].name);
        Debug.Log("Active: " + weapons[index].activeSelf);
    }

    void NextWeapon()
    {
        if (weapons.Length == 0)
            return;

        int nextIndex = (currentWeaponIndex + 1) % weapons.Length;

        Debug.Log("Switching to index: " + nextIndex);

        EquipWeapon(nextIndex);
    }

}