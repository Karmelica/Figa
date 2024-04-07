using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Figa : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform player;
    private int hp = 5;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Application.Quit();
        }
    }

    public void TakeDmg()
    {
        hp--;
        if(hp <= 0)
        {
            SceneManager.LoadScene(3);
            gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponentInParent<NavMeshAgent>();
        hp = 5;
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(player.position);
    }
}
