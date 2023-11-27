using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Level2EnemyMovement : MonoBehaviour
{
    public Transform target; // Assign this to the player's Transform in the Unity Editor
    public float radius = 10f; // Set this to the desired radius in the Unity Editor

    private NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= radius)
        {
            agent.SetDestination(target.position);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level 2");
        }
    }
}