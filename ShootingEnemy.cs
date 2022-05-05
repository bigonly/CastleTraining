using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVS.AI;

[ExecuteInEditMode]
public class ShootingEnemy : MonoBehaviour
{
    private Transform player;
    public Transform firePoint;
    public float shootingDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public AIPlayerDetector playerDetector;
    // Start is called before the first frame update


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0 && playerDetector.PlayerDetected)
        {
            Instantiate(projectile, firePoint.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}