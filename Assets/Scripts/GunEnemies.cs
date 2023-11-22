using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunEnemies : MonoBehaviour
{
    public Transform target; // Assign this to the player's Transform in the Unity Editor
    public float radius = 10f; // Set this to the desired radius in the Unity Editor

    public Transform bulletSpawnPoint;
    public GameObject enemyBullet;

    public float shootDelay = 2.0f; // Adjust this to set the delay before shooting
    private float timeSinceLastShot = 0.0f;

    public float bulletSpeed = 10f;

    private Vector3 originalPosition; // Store the enemy's original position

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, originalPosition);

        if (distance <= radius)
        {
            // Update the timer and check if it's time to shoot
            timeSinceLastShot += Time.deltaTime;
            if (timeSinceLastShot >= shootDelay)
            {
                Shoot();
                timeSinceLastShot = 0.0f; // Reset the timer
            }
        }

        // Update the rotation to look at the player without changing the position
        Vector3 lookAtPosition = target.position;
        lookAtPosition.y = transform.position.y; // Keep the same Y position
        transform.LookAt(lookAtPosition);
    }

    void Shoot()
    {
        foreach (Transform spawnPoint in bulletSpawnPoint)
        {
            GameObject bullet = Instantiate(enemyBullet, spawnPoint.position, spawnPoint.rotation);

            // Adjust the bullet's initial rotation to be level with the enemy's rotation
            bullet.transform.rotation = Quaternion.LookRotation(target.position - bulletSpawnPoint.position);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(bullet.transform.forward * bulletSpeed, ForceMode.Impulse);

			Destroy(bullet, 6.0f);
        }
		
		
    }
   
}