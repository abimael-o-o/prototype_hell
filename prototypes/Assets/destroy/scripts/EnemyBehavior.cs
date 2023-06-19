using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public GameObject attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
        if(enemy.remainingDistance < enemy.stoppingDistance && enemy.remainingDistance != 0)
        {
            attack.SetActive(true);
        }
        else
        {
            attack.SetActive(false);
        }
    }
}
