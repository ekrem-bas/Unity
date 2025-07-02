using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "TowerData")]
public class TowerData : ScriptableObject
{
    public int price; // Kule fiyatı
    public float damage; // Kule hasarı
    public float bulletSpeed; // Kule mermi hızı
    public float shootTimer; // Kule atış zamanlayıcısı
}