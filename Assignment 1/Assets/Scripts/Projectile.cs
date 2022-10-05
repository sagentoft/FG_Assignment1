using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody projectileBody;
    private bool isActive;

    public void Initialize(Vector3 direction)
    {
        isActive = true;

        projectileBody.AddForce(direction);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            projectileBody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
            //transform.Translate(transform.forward * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.GetComponent<ActivePlayerHealth>().TakeDamage(10);
            Debug.Log("Hit");
        }
        Destroy(gameObject);
        
    }
}
