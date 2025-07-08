using System.Collections;
using System.Collections.Generic;
using Scripts.Enemy;
using Scripts.Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characterPrefabs; // Karakter prefab'ları
    private int currentIndex = 0; // Seçili karakterin indeksi
    private GameObject currentCharacter; // Şu anki karakter objesi
    public GameObject characterSpawnPoint; // Karakterin spawn edileceği nokta
    public Rigidbody currentRigidbody; // Şu anki karakterin Rigidbody bileşeni
    public NavMeshAgent currentNavMeshAgent; // Şu anki karakterin NavMeshAgent bileşeni
    public PlayerData playerData; // PlayerData scripti

    public void ShowCharacter(int index)
    {
        if (currentCharacter != null)
            Destroy(currentCharacter);

        currentIndex = index;
        currentCharacter = Instantiate(characterPrefabs[currentIndex], characterSpawnPoint.transform.position, Quaternion.identity);
        currentCharacter.transform.rotation = Quaternion.Euler(0, 135, 0);

        currentRigidbody = currentCharacter.GetComponent<Rigidbody>();
        currentRigidbody.isKinematic = true;

        currentNavMeshAgent = currentCharacter.GetComponent<NavMeshAgent>();

        // Hatalı scriptleri devre dışı bırak
        var movement = currentCharacter.GetComponent<PlayerMovement>();
        if (movement != null)
            movement.enabled = false;

        var healthManager = currentCharacter.GetComponent<PlayerHealthManager>();
        if (healthManager != null)
            healthManager.enabled = false;

        var spawner = currentCharacter.GetComponent<EnemySpawner>();
        if (spawner != null)
            spawner.enabled = false;

        var detector = currentCharacter.GetComponent<EnemyDetector>();
        if (detector != null)
            detector.enabled = false;

        if (currentNavMeshAgent != null)
        {
            Destroy(currentNavMeshAgent);
        }
    }

    public void SelectCharacter()
    {
        playerData.selectedCharacterPrefab = characterPrefabs[currentIndex]; // Seçilen karakteri PlayerData'ya ata
        SceneManager.LoadScene("MainMenuScene"); // Menu sahnesine geç
    }
}
