using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody projectileBody;
    [SerializeField] private GameObject damageIndicatorPrefab;
    private bool isActive;

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            //projectileBody.MovePosition(transform.position + transform.forward * (speed * Time.deltaTime));
            transform.Translate(transform.forward * (speed * Time.deltaTime));
        }
    }

    public void Initialize()
    {
        isActive = true;
        projectileBody.AddForce(transform.forward * 500f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //GameObject collisionObject = collision.gameObject;
        //DestructionFree destruction = collisionObject.GetComponent<DestructionFree>();
        //if (destruction == null)
        //{
            //Destroy(collisionObject);
            GameObject damageIndicator = Instantiate(damageIndicatorPrefab);
            damageIndicator.transform.position = transform.position;
        //}
        Destroy(gameObject);
        TurnManager.GetInstance().ChangeTurn();
    }
}
