using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject playerInstance; // Inspector'dan PlayerRoot'u ata
    public PlayerData playerData;
    void Start()
    {
        playerInstance = Instantiate(playerData.selectedCharacterPrefab, spawnPoint.position, Quaternion.identity);
    }
}
