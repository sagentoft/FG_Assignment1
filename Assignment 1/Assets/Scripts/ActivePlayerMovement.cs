using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayerMovement : MonoBehaviour
{
    [SerializeField] private ActivePlayerManager manager;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveSpeed;

    [SerializeField] private Camera characterCamera;
    [SerializeField] private float speedH = 2.0f;
    [SerializeField] private float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    [SerializeField] private float pitchClamp = 90;

    private Rigidbody playerBody;
    private bool isGrounded = true;
    [SerializeField] private float jumpHeight = 300;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            ActivePlayer currentPlayer = manager.GetCurrentPlayer();
            currentPlayer.transform.Translate(currentPlayer.transform.right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            ActivePlayer currentPlayer = manager.GetCurrentPlayer();
            currentPlayer.transform.Translate(currentPlayer.transform.forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"), Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            ActivePlayer currentPlayer = manager.GetCurrentPlayer();
            playerBody = currentPlayer.GetComponent<Rigidbody>();
            playerBody.AddForce(transform.up * jumpHeight);
            isGrounded = false;
        }

        ReadRotationInput();
    }

    private void ReadRotationInput()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -pitchClamp, pitchClamp);

        characterCamera.transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3) // I made layer 3 "Floor", which I have assigned to all applicable surfaces
        {
            isGrounded = true;
        }
    }
}
