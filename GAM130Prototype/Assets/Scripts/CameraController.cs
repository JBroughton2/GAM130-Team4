using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float mouseSensitivity = 100;
    [SerializeField]
    private Transform player;

    public Rigidbody rb;
    private Vector3 eulerVelocity;
    private float xAxisClamp;

    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        Debug.Log(mouseX);

        xAxisClamp += mouseY;

        if (xAxisClamp > 90)
        {
            xAxisClamp = 90;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90);
        }

        transform.Rotate(Vector3.left * mouseY);
        Quaternion rotX = Quaternion.Euler(0, mouseX, 0);
        rb.MoveRotation(rb.rotation * rotX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
