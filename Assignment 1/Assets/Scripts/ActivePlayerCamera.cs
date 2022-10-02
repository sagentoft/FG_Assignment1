using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ActivePlayerCamera : MonoBehaviour
{
    [SerializeField] private ActivePlayerManager manager;
    [SerializeField] private Vector3 distanceFromPlayer;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
       Vector3 targetPosition = manager.GetCurrentPlayer().transform.position + distanceFromPlayer;

        //Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}
