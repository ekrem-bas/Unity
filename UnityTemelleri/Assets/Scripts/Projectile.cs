using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Projectile : MonoBehaviour
{
    public float damage; // Mermi hasarı

    public static void Shoot(GameObject target, Transform bulletSpawnPoint, GameObject bulletPrefab, float damage = 50f, float speed = 20f, float lifetime = 7f)
    {
        if (target == null || bulletPrefab == null || bulletSpawnPoint == null) return;

        // Hedefe doğru yön hesapla
        Collider targetCollider = target.GetComponent<Collider>();
        Vector3 direction = (targetCollider.bounds.center - bulletSpawnPoint.transform.position).normalized;

        // Bullet'ın hedefe doğru bakması için rotation hesapla
        // Eğer bullet'ın ucu Z ekseni ise (normal):
        Quaternion bulletRotation = Quaternion.LookRotation(direction);

        // Mermi prefabını hedefe doğru bakan rotation ile oluştur
        GameObject bullet = Object.Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletRotation);

        bullet.GetComponent<Projectile>().damage = damage; // Merminin hasarını ayarla

        // Merminin Rigidbody bileşenini al
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(direction * speed, ForceMode.Impulse); // Mermiyi hedefe doğru it

        // Mermiyi belirli bir süre sonra yok et
        Object.Destroy(bullet, lifetime);
    }
}
