using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform ShootingPoint;
    public GameObject BulletPrefab;
    

    IEnumerator Shoot()
    {   
        while (true)
        {
            Instantiate(BulletPrefab, ShootingPoint.position, ShootingPoint.rotation, null);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void StartShooting()
    {
        StartCoroutine(Shoot());
    }

    public void StopShooting()
    {
        StopAllCoroutines();
    }
}
