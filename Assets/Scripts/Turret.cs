using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public GameObject barrel;
    [Tooltip("Level where the turret is")]
    public GameObject level;
    [Tooltip("Check if you want the turret to face player")]
    public bool rotateToPlayer;

    [Header("Turret stats")]
    [Tooltip("Bullets per second")]
    public float fireRate = 1;
    public float bulletSpeed = 3;
    [Range(0,2)]
    public float turnSpeed = 1;

    float _canShoot;
    void Start()
    {
        _canShoot = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (level == GameManager.instance.currentLevel)
        {
            if (Time.time >= _canShoot)
            {
                Shoot();
                _canShoot += 1 / fireRate;
            }
        }
        StartCoroutine(TurnTurret());
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Bullet>().speed = bulletSpeed;
    }

    IEnumerator TurnTurret()
    {
        if (rotateToPlayer)
        {
            Vector3 direction = GameManager.instance.player.transform.position - barrel.transform.position;

            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - 180;
            Vector3 directionVector = new Vector3(0, angle, 0);
            float step = .2f * turnSpeed;
            barrel.transform.rotation = Quaternion.RotateTowards(barrel.transform.rotation, Quaternion.Euler(directionVector), step);
            yield return new WaitForSeconds(.005f); 
        }
    }
}
