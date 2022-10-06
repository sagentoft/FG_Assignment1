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
            currentPlayer.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            ActivePlayer currentPlayer = manager.GetCurrentPlayer();
            currentPlayer.transform.Translate(currentPlayer.transform.forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"), Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            StartCoroutine(JumpCoroutine());
        }

        if (Input.GetMouseButtonDown(0))
        {
            ActivePlayer currentPlayer = manager.GetCurrentPlayer();
            currentPlayer.GetComponent<PlayerWeapon>().ShootLaser();
            manager.ChangeTurn();
        }

    }
  
    private IEnumerator JumpCoroutine()
    {
        ActivePlayer currentPlayer = manager.GetCurrentPlayer();
        playerBody = currentPlayer.GetComponent<Rigidbody>();
        playerBody.AddForce(transform.up * jumpHeight);
        isGrounded = false;
        yield return new WaitForSeconds(1.2f);
        isGrounded = true;

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor") // I made layer 3 "Floor", which I have assigned to all applicable surfaces
        {
            isGrounded = true;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        bool result = Physics.SphereCast(transform.position, 0.15f, -transform.up, out hit, 1f);
        return result;
    }
}
