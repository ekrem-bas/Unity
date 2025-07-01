using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectClosestEnemy : MonoBehaviour
{
    [SerializeField] private GameObject closestEnemy; // En yakın düşman
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        closestEnemy = ClosestEnemy(); // En yakın düşmanı bul

        // Eğer en yakın düşman varsa ona bak
        if (closestEnemy != null)
        {
            player.transform.LookAt(closestEnemy.transform); // Oyuncu en yakın düşmana bakar
        }
    }

    GameObject ClosestEnemy()
    {
        // Eğer hiç düşman yoksa null döndür
        if (Enemy.allEnemies.Count == 0)
            return null;

        GameObject closest = Enemy.allEnemies[0];
        float closestDistance = Mathf.Infinity; // En yakın mesafe başlangıçta sonsuz olarak ayarlanır

        foreach (GameObject enemy in Enemy.allEnemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position); // Düşman ile bu nesne arasındaki mesafeyi hesapla
            if (distance < closestDistance) // Eğer bu düşman daha yakınsa
            {
                closestDistance = distance; // En yakın mesafeyi güncelle
                closest = enemy; // En yakın düşmanı güncelle
            }
        }
        return closest;
    }
}
