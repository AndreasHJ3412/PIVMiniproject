using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    
    public float fireCooldown = 0.25f;  // Adjust the cooldown time as needed
    private float nextFireTime;
    
    // Start is called before the first frame update
    void Start()
    {
        nextFireTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFireTime)
        {
            ShootBullet();
            nextFireTime = Time.time + fireCooldown;
        }
    }
    
    public void ShootBullet()
    {
        //RaycastHit hit;
        /*if (Physics.Raycast(bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.forward, out hit,
                bulletSpeed))*/
        //{
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
        
            rb.AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.Impulse);

            Destroy(bullet, 3.0f);
        //}
    }
    

}