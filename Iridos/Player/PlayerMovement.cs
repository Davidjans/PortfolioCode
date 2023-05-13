using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1;
    public float cameraSensitivity = 50;

    public Transform playerCamera;
    float mouseY;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed;
        movement = transform.TransformDirection(movement);
        rb.velocity = movement;
        transform.Rotate(0, mouseX, 0);


        mouseY -= Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -89f, 89f);

        playerCamera.localRotation = Quaternion.Euler(mouseY, 0, 0);
    }
}
