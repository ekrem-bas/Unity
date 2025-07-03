using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    public GameObject playerInstance; // Inspector'dan PlayerRoot'u ata

    void Start()
    {
        string selectedName = PlayerPrefs.GetString("SelectedCharacterName", "");
        foreach (var prefab in characterPrefabs)
        {
            if (prefab.name == selectedName)
            {
                playerInstance = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
                break;
            }
        }
    }
}
