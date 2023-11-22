using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity = 2.0f; // Sensitivity of camera movement
    public float minYAngle = -80.0f; // Minimum vertical angle
    public float maxYAngle = 80.0f; // Maximum vertical angle

    private float rotationX = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Will lock the curser on the screen as we move around
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        // Get mouse input for camera rotation
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotate the camera horizontally (left and right)
        transform.Rotate(0, mouseX, 0);

        // Calculate vertical rotation with clamping
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minYAngle, maxYAngle);

        // Rotate the camera vertically (up and down)
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
