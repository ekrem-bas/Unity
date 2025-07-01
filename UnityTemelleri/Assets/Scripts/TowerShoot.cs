using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Mermi prefab
    [SerializeField] private Transform spawnPoint; // Merminin spawn edileceği nokta
    [SerializeField] private float bulletSpeed = 20f; // Merminin hızı
    private GameObject shootTarget; // Merminin hedefi
    private float shootTimer = 4f; // Atış zamanlayıcısı
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0f, shootTimer);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Shoot()
    {
        DetectClosestEnemy detector = GetComponent<DetectClosestEnemy>();
        shootTarget = detector.GetClosestEnemy(); // En yakın düşmanı al
        if (shootTarget == null) return;
        // Hedefe doğru yön hesapla
        Vector3 direction = (shootTarget.transform.position - spawnPoint.position).normalized;

        // Mermi prefabını spawnPoint'ten oluştur
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);

        // Merminin Rigidbody bileşenini al
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.isKinematic = false;
        bulletRb.AddForce(direction * bulletSpeed, ForceMode.Impulse); // Mermiyi hedefe doğru it

        // Mermiyi 7 saniye sonra otomatik olarak yok et (değmezse)
        Destroy(bullet, 7f);
    }
}
