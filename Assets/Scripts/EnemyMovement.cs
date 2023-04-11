using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]

public class EnemyMovement : MonoBehaviour
{
    
    private Transform target;
    private int wavepointIndex = 1;
    private NavMeshAgent nav;
    private GameObject end;

    private Enemy enemy;
    private void Start()
    {
        nav = this.GetComponent<NavMeshAgent>();
        enemy = GetComponent<Enemy>();
        end = GameObject.Find("END");
        target = end.transform;
    }
    private void Update()
    {
        enemy.speed = enemy.startSpeed;
        nav.speed = enemy.speed;
        nav.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("end"))
        {
            EndPath();
        }
        Debug.Log("End reached");
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
