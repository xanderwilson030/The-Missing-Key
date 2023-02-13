using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    // Private
    Rigidbody rb;

    // Public
    [SerializeField] float accelerationSpeed;
    [SerializeField] float baseSpeed;
    [SerializeField] float dragForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

    }

    private void FixedUpdate()
    {
        Vector3 down = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, down, 10))
        {
            Debug.Log("Ground Detected");
            rb.position = new Vector3(rb.gameObject.transform.position.x, , rb.gameObject.transform.position.z);
        }
    }

    private void PlayerMovement()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float zMovement = Input.GetAxisRaw("Vertical");

        Vector3 movementVector = new Vector3(xMovement, rb.velocity.y, zMovement) * baseSpeed * accelerationSpeed * Time.deltaTime;

        rb.velocity = movementVector;
    }
}
