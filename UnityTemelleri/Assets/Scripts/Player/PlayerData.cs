using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    public GameObject[] characterPrefabs; // Karakter prefab'ları
    public GameObject selectedCharacterPrefab; // Seçilen karakter prefab'ı
    public float maxHealth; // Oyuncunun maksimum canı
    public float health; // Oyuncunun şu anki canı
    public float speed; // Oyuncunun hızı
    public float beamSkillDamage;
    public float meteorSkillDamage;
}
