using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Scripts.Enemy;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 50f; // Mermi hasarı

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Enemy scriptini al ve hasar ver
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Bullet'ın kendi damage değerini kullan
            }

            Destroy(gameObject); // Mermiyi yok et
        }
    }

    public static void Shoot(GameObject target, Transform bulletSpawnPoint, GameObject bulletPrefab, float damage = 50f, float speed = 20f, float lifetime = 7f)
    {
        if (target == null || bulletPrefab == null || bulletSpawnPoint == null) return;

        // Hedefe doğru yön hesapla
        Vector3 direction = (target.transform.position - bulletSpawnPoint.transform.position).normalized;

        // Bullet'ın hedefe doğru bakması için rotation hesapla
        // Eğer bullet'ın ucu Z ekseni ise (normal):
        Quaternion bulletRotation = Quaternion.LookRotation(direction);

        // Mermi prefabını hedefe doğru bakan rotation ile oluştur
        GameObject bullet = Object.Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletRotation);

        bullet.GetComponent<Bullet>().damage = damage; // Merminin hasarını ayarla

        // Merminin Rigidbody bileşenini al
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(direction * speed, ForceMode.Impulse); // Mermiyi hedefe doğru it

        // Mermiyi belirli bir süre sonra yok et
        Object.Destroy(bullet, lifetime);
    }
}
