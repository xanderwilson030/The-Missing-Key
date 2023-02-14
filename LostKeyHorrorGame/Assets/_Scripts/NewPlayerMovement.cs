using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    // Public
    [SerializeField] Camera _camera;
    [SerializeField] float speed = 2f;
    [SerializeField] float sensitivity = 2f;

    // Private
    private float moveFB;
    private float moveLR;
    private float rotX;
    private float rotY;
    private float verticalVelocity = -9.8f;
    private CharacterController characterController;

    void Start()
    {
        // Locking the cursor to the screen
        Cursor.lockState = CursorLockMode.Locked;

        // Obtaining important components from the player
        characterController = gameObject.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        // Move is called every frame, notice that it is not a fixed update
        Move();
    }

    private void Move()
    {
        // Grabbing vertical, hortizontal,and mouse movements
        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;
        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;

        // Clamping the y movement to lock how high and low the player can look
        rotY = Mathf.Clamp(rotY, -60f, 60f);

        // Creating the movement vector
        Vector3 movement = new Vector3(moveLR, verticalVelocity, moveFB);

        // Rotating the player camera
        transform.Rotate(0, rotX, 0);
        _camera.transform.localRotation = Quaternion.Euler(rotY, 0, 0);

        // Moving the player
        movement = transform.rotation * movement;
        characterController.Move(movement * Time.deltaTime);
    }

}
