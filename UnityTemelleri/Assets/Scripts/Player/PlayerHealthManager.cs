using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    public PlayerData playerData;
    public Healthbar healthbar; // Sağlık çubuğu scripti
    // Start is called before the first frame update

    void Start()
    {
        healthbar = FindObjectOfType<Healthbar>(); // Sağlık çubuğu scriptini bul
        if (healthbar == null)
        {
            Debug.LogError("Healthbar script not found in the scene.");
            return;
        }
        playerData.health = playerData.maxHealth; // Oyuncunun canını maksimum can olarak ayarla
        healthbar.UpdateHealthbar(playerData.maxHealth, playerData.health); // Sağlık çubuğunu güncelle
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magic"))
        {
            // Magic'in hasarını al
            float damage = other.GetComponent<Projectile>().damage;
            // Oyuncunun canını azalt
            playerData.health -= damage;
            // Sağlık çubuğunu güncelle
            healthbar.UpdateHealthbar(playerData.maxHealth, playerData.health);
            if (playerData.health <= 0)
            {
                SceneManager.LoadScene("GameOverScene"); // Oyuncu öldüğünde GameOver sahnesine geç
            }
            // Mermiyi yok et
            Destroy(other.gameObject);
        }
    }
}
