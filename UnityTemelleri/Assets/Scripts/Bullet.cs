using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet
{
    public static void Shoot(GameObject target, Transform bulletSpawnPoint, GameObject bulletPrefab, float speed = 20f, float lifetime = 7f)
    {
        if (target == null || bulletPrefab == null || bulletSpawnPoint == null) return;

        // Hedefe doğru yön hesapla
        Vector3 direction = (target.transform.position - bulletSpawnPoint.transform.position).normalized;

        // Mermi prefabını oluştur
        GameObject bullet = Object.Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, Quaternion.identity);

        // Merminin Rigidbody bileşenini al
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(direction * speed, ForceMode.Impulse); // Mermiyi hedefe doğru it

        // Mermiyi belirli bir süre sonra yok et
        Object.Destroy(bullet, lifetime);
    }
}
