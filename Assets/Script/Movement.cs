using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraRotation : MonoBehaviour
{
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private Vector3 forwardDirection;
    private Vector3 backwardDirection;
    private Vector3 initialPosition;
    public float rotationSpeed = 2f;
    public float movementSpeed = 5f;

    void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = initialRotation;
        initialPosition = transform.position;
        forwardDirection = Vector3.forward;
        backwardDirection = Vector3.back;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            targetRotation *= Quaternion.Euler(0f, 90f, 0f);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            targetRotation = initialRotation;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            targetRotation *= Quaternion.Euler(0f, -90f, 0f);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            targetRotation = initialRotation;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            targetRotation *= Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            targetRotation = initialRotation;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += forwardDirection * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += backwardDirection * movementSpeed * Time.deltaTime;
        }

        Vector3 newPosition = transform.position;
        newPosition.x = initialPosition.x;
        transform.position = newPosition;
    }
}
