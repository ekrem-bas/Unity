using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image healthbarImage; // Sağlık çubuğu görseli

    private Camera cam; // Ana kamera referansı

    void Start()
    {
        cam = Camera.main;
    }
    public void UpdateHealthbar(float maxHealth, float currentHealth)
    {
        // Sağlık çubuğunu güncelle
        healthbarImage.fillAmount = currentHealth / maxHealth;
    }

    void Update()
    {
        // Kameraya bakacak şekilde sağlık çubuğunu döndür
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }
}
