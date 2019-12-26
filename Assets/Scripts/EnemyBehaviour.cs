using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;
    public int health = 3;
    public Slider slider;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
      agent.SetDestination(player.transform.position);
    }
}
