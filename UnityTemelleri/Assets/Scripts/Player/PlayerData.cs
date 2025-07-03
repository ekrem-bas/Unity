using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    public GameObject[] characterPrefabs; // Karakter prefab'ları
    public GameObject selectedCharacterPrefab; // Seçilen karakter prefab'ı
    void Start()
    {
        string selectedCharacterName = PlayerPrefs.GetString("SelectedCharacterName", "");
        if (!string.IsNullOrEmpty(selectedCharacterName))
        {
            foreach (var prefab in characterPrefabs)
            {
                if (prefab.name == selectedCharacterName)
                {
                    selectedCharacterPrefab = prefab; // Seçilen karakter prefab'ını ayarla
                    return; // Seçilen karakter bulundu, döngüden çık
                }
            }
        }
    }
}
