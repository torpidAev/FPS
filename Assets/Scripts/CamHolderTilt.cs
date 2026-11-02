using UnityEngine;
using UnityEngine.InputSystem;

public class CamHolderTilt : MonoBehaviour
{
    [Header("Tilt Configuration")]
    [Range(0, 20)] public float tiltAmount = 5f;    
    [Range(1, 30)] public float tiltSpeed = 12f;   

    private float currentTiltZ = 0f;

    void Update()
    {
        float horizontalInput = 0f;
        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) horizontalInput = -1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) horizontalInput = 1f;
        }
        else
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
        }

        float targetTilt = -horizontalInput * tiltAmount;

        currentTiltZ = Mathf.MoveTowards(currentTiltZ, targetTilt, tiltSpeed * Time.deltaTime * 20f);

        transform.localRotation = Quaternion.Euler(0f, 0f, currentTiltZ);
    }
}