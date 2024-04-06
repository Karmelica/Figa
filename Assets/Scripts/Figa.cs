using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Figa : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform player;
    private int hp = 5;

    public void TakeDmg()
    {
        hp--;
        Debug.Log("Trfienie, hp: " + hp);
        if(hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        hp = 5;
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(player.position);
    }
}
