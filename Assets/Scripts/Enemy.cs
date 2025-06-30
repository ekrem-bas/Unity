using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject target; // oyuncu
    private NavMeshAgent agent; // NavMeshAgent bileşeni
    float speed = 2f; // düşmanın hareket hızı

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed; // düşmanın hızını ayarla
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position); // düşmanı oyuncuya doğru hareket ettir
    }
}
