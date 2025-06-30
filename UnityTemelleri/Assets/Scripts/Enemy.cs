using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject target; // oyuncu
    private NavMeshAgent agent; // NavMeshAgent bileşeni
    float speed = 2f; // düşmanın hareket hızı

    [SerializeField] private Healthbar healthbar; // sağlık çubuğu scripti
    float maxHealth = 100f; // düşmanın maksimum canı
    float health = 100f; // düşmanın canı
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed; // düşmanın hızını ayarla
        healthbar = GetComponentInChildren<Healthbar>(); // sağlık çubuğu scriptini al
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        healthbar.UpdateHealthbar(maxHealth, health);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position); // düşmanı oyuncuya doğru hareket ettir
        health -= 15 * Time.deltaTime; // düşmanın canını azalt
        healthbar.UpdateHealthbar(maxHealth, health); // sağlık çubuğunu güncelle
        if (health <= 0)
        {
            Destroy(gameObject); // düşman öldüğünde yok et
        }
    }
}
