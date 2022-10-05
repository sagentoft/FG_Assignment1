using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private float weaponDamage;
    [SerializeField] private Transform weaponBarrel;
    [SerializeField] private LineRenderer lineRenderer;

    public void ShootLaser()
    {
        //RaycastHit result;
        //bool thereWasHit = Physics.Raycast(weaponBarrel.position, transform.forward, out result, Mathf.Infinity);

        //lineRenderer.SetPosition(0, weaponBarrel.position);

        //if (thereWasHit)
        ////  ActivePlayerHealth activePlayerHealth = result.collider.GetComponent<ActivePlayerHealth>();
        // if (activePlayerHealth != null)
        // {
        //   activePlayerHealth.TakeDamage(weaponDamage);
        //}
        //lineRenderer.SetPosition(1, result.point);
        //}
        // else
        //{
        //  lineRenderer.SetPosition(1, weaponBarrel.position + transform.position * 50);
        //}

        Vector3 force = transform.forward;
        GameObject newprojectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        newprojectile.transform.position = weaponBarrel.position;
        newprojectile.GetComponent<Projectile>().Initialize(force);
    }


}
