using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Level1Explosion : MonoBehaviour 
{

    public float cubeSize = 0.2f;
    public int cubesInRow = 5;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    GameObject piece;
    
    public Level1KillCounter killCounter; // Reference to the KillCounter script
    
	void Start() 
	{
        //To calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
        
	}
	
    private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("PlayerBullet")) 
		{
            explode();
		}
    }

    public void explode() 
	{
		
		
        //Makes the cube disappear
        gameObject.SetActive(false);
        //To destroy the cubes after 2.5 seconds
        Destroy(gameObject, 2.5f);
        

        //To loop 3 times to create 5x5x5 pieces in x, y, z coordinates
        for (int x = 0; x < cubesInRow; x++) 
			{
            for (int y = 0; y < cubesInRow; y++) 
				{
                for (int z = 0; z < cubesInRow; z++) 
					{
                    createPiece(x, y, z);
                	}
            	}
       		 }
        

        //To get explosion position
        Vector3 explosionPos = transform.position;
        //To get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //To add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders) 
		{
            //To get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null) 
			{
                //To add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
	        killCounter.IncrementKillCount();

	}

    void createPiece(int x, int y, int z) 
	{

        //Create piece
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

		// Get the Renderer component from the new cube
        var cubeRenderer = piece.GetComponent<Renderer>();

        // Call SetColor using the shader property name "_Color" and setting the color to red
        cubeRenderer.material.SetColor("_Color", Color.red);


        //To set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //To add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
        
        //To destroy the cubes after 2.5 seconds
        Destroy(piece, 2.5f);
        

    }
    
    
}