using System.Collections;
using System.Collections.Generic;
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
        currentCharacter.transform.rotation = Quaternion.Euler(0, 180, 0); // Karakteri doğru yönde döndür
        currentRigidbody = currentCharacter.GetComponent<Rigidbody>(); // Rigidbody bileşenini al
        currentRigidbody.isKinematic = true; // Rigidbody'yi kinematik yap
        currentNavMeshAgent = currentCharacter.GetComponent<NavMeshAgent>();
        // burada healthbar'a erişmek istediği için hata geliyor
        currentCharacter.GetComponent<PlayerHealthManager>().enabled = false;
        if (currentNavMeshAgent != null)
        {
            Destroy(currentNavMeshAgent); // NavMeshAgent'ı tamamen sil
        }
    }

    public void SelectCharacter()
    {
        playerData.selectedCharacterPrefab = characterPrefabs[currentIndex]; // Seçilen karakteri PlayerData'ya ata
        SceneManager.LoadScene("MainMenuScene"); // Menu sahnesine geç
    }
}
