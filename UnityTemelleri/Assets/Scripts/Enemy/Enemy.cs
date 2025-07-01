using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        // Tüm düşmanları tutan static liste
        public static List<GameObject> allEnemies = new List<GameObject>();
        [SerializeField] private GameObject target; // oyuncu
        private NavMeshAgent agent; // NavMeshAgent bileşeni
        float speed = 2f; // düşmanın hareket hızı

        [SerializeField] private Healthbar healthbar; // sağlık çubuğu scripti
        float maxHealth = 100f; // düşmanın maksimum canı
        float health = 100f; // düşmanın şu anki canı
        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.speed = speed; // düşmanın hızını ayarla
            healthbar = GetComponentInChildren<Healthbar>(); // sağlık çubuğu scriptini al
        }

        // Start is called before the first frame update
        void Start()
        {
            // Bu düşmanı listeye ekle
            allEnemies.Add(gameObject);
            target = GameObject.FindGameObjectWithTag("Player");
            healthbar.UpdateHealthbar(maxHealth, health);
        }

        // Update is called once per frame
        void Update()
        {
            agent.SetDestination(target.transform.position); // düşmanı oyuncuya doğru hareket ettir
        }


        public void TakeDamage(float damage)
        {
            health -= damage;
            healthbar.UpdateHealthbar(maxHealth, health); // sağlık çubuğunu güncelle

            if (health <= 0) // Eğer canı sıfır veya altına düşerse
            {
                Destroy(gameObject); // düşmanı yok et
            }
        }

        // Nesne yok edilirken çağrılır
        void OnDestroy()
        {
            allEnemies.Remove(gameObject);
        }
    }
}