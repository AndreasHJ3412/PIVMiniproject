using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 10.0f;
    private float sensitivity = 2.0f;
    private float rotationX = 0.0f;

    private float slowGameSpeed = 0.1f;
    private float normalGameSpeed = 1f;

    private bool isMoving = false;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float rotX = Input.GetAxis("Mouse X");
        float rotY = Input.GetAxis("Mouse Y");

        // Update the horizontal rotation of the player
        transform.Rotate(0, rotX * sensitivity, 0);

        // Update the vertical rotation of the camera
        rotationX -= rotY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Clamp vertical rotation to prevent flipping

        // Apply the vertical rotation to the camera (assuming your camera is a child of the player object)
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * speed;
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * Time.deltaTime * speed;
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * speed;
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * Time.deltaTime * speed;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            Time.timeScale = normalGameSpeed;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else
        {
            Time.timeScale = slowGameSpeed;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }
    
}