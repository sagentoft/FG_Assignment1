using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingStartPosition;

    private void Update()
    {
        bool IsPlayerTurn = playerTurn.IsPlayerTurn();
        if (TurnManager.GetInstance().IsItPlayerTurn(playerIndex))
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject newProjectile = Instantiate(projectilePrefab);
                newProjectile.transform.position = shootingStartPosition.position;
                newProjectile.GetComponent<ProjectileScript>().Initialize(force);
            }
        }
    }
}
