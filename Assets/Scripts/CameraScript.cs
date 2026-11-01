using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Header("Mouse Look")]

    [SerializeField] private float sensitivity;

    [SerializeField] private float verticalLimit;

    [SerializeField] private float smoothSpeed;

    [Header("CameraTilt")]

    [SerializeField] private float tiltAmount;

    [SerializeField] private float tiltStartSpeed;

    [SerializeField] private float tiltEndSpeed;

    [Header("References")]

    [SerializeField] private Transform orientation;

    [SerializeField] private Transform body;

    private float xRotation = 0f;

    private float yRotation = 0f;

    private float currentX;

    private float currentY;

    private float currentTilt = 0f;

    private float targetTilt = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentX = xRotation;
        currentY = yRotation;
    }

    // Update is called once per frame
    void Update()
    {
        MouseLook();
        CameraTilt();
    }


    void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalLimit, verticalLimit);

        currentX = Mathf.Lerp(currentX, xRotation, smoothSpeed * Time.deltaTime);
        currentY = Mathf.Lerp(currentY, yRotation, smoothSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(currentX, currentY, currentTilt);
        orientation.rotation = Quaternion.Euler(0, currentY, 0);
        body.rotation = Quaternion.Euler(0, currentY, 0);
    }


    private void CameraTilt()
    {
        bool leftStrafe = Input.GetKey(KeyCode.A);
        bool rightStrafe = Input.GetKey(KeyCode.D);

        if (leftStrafe && !rightStrafe)
            targetTilt = tiltAmount;
        else if (rightStrafe && !leftStrafe)
            targetTilt = -tiltAmount;
        else
            targetTilt = 0f;
        float smoothTilt;
        if (targetTilt == 0)
            smoothTilt = tiltEndSpeed;
        else
            smoothTilt = tiltStartSpeed;

        currentTilt = Mathf.Lerp(currentTilt, targetTilt, smoothTilt * Time.deltaTime);
    }
}
