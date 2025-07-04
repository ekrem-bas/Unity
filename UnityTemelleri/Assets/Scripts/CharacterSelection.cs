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

    public void Start()
    {
        PlayerPrefs.DeleteKey("SelectedCharacterName"); // Seçilen karakter ismini temizle
    }
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
        if (currentNavMeshAgent != null)
        {
            Destroy(currentNavMeshAgent); // NavMeshAgent'ı tamamen sil
        }
    }

    public void SelectCharacter()
    {
        PlayerPrefs.SetString("SelectedCharacterName", characterPrefabs[currentIndex].name);
        PlayerPrefs.Save(); // Seçilen karakter ismini kaydet
        Debug.Log("Selected Character: " + PlayerPrefs.GetString("SelectedCharacterName"));
        SceneManager.LoadScene("MenuScene"); // Menu sahnesine geç
    }
}
