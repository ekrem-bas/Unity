using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Mermi prefab
    [SerializeField] private Transform spawnPoint; // Merminin spawn edileceği nokta
    [SerializeField] private float bulletSpeed = 20f; // Merminin hızı
    private GameObject shootTarget; // Merminin hedefi
    private float shootTimer = 2f; // Atış zamanlayıcısı
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0f, shootTimer); // Her 5 saniyede bir Shoot fonksiyonunu çağır
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Shoot()
    {
        shootTarget = GetComponent<DetectClosestEnemy>().GetClosestEnemy(); // En yakın düşmanı al
        if (shootTarget == null) return; // Eğer en yakın düşman yoksa atış yapma

        // Hedefe doğru yön hesapla
        Vector3 direction = (shootTarget.transform.position - spawnPoint.position).normalized;

        // Mermi prefabını spawnPoint'ten oluştur
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);

        // Merminin Rigidbody bileşenini al
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.isKinematic = false;
        bulletRb.AddForce(direction * bulletSpeed, ForceMode.Impulse); // Mermiyi hedefe doğru it

    }
}
