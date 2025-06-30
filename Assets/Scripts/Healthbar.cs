using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image healthbarImage; // Sağlık çubuğu görseli

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }
    // Start is called before the first frame update
    public void UpdateHealthbar(float maxHealth, float currentHealth)
    {
        healthbarImage.fillAmount = currentHealth / maxHealth;
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }
}
