using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Rigidbody charBody;
    private bool hasJumped = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(transform.right * (speed * Time.deltaTime * Input.GetAxis("Horizontal")));
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(transform.forward * (speed * Time.deltaTime * Input.GetAxis("Vertical")));
        }

        if (Input.GetKeyDown(KeyCode.Space) && charBody.velocity.y <= Mathf.Epsilon)
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (!hasJumped)
        {
            charBody.AddForce(Vector3.up * 300f);
            hasJumped = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        hasJumped = false;
    }
}