using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannonbulletPrefabs;
    public Transform firePoint;

    [SerializeField]
    [Range(0f, 100f)]
    private float fireForce;

    [SerializeField]
    private float fireRate;

    private float timeCount;

    void Awake()
    {
        timeCount = 1;
    }

    void Update()
    {
        timeCount += Time.deltaTime;

        if (timeCount > fireRate)
        {
            FireCannon();
            timeCount = 0;
        }
    }

    void FireCannon()
    {
        GameObject bullet = Instantiate(cannonbulletPrefabs, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        Vector3 direction = firePoint.forward;

        bulletRb.AddForce(direction * fireForce, ForceMode.Impulse);
    }
}
