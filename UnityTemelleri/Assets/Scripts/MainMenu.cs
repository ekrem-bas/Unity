using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public PlayerData playerData;
    private static bool isGameStarted = false;
    void Awake()
    {
        if (!isGameStarted)
        {
            isGameStarted = true;
            playerData.selectedCharacterPrefab = null;
        }
    }

    public void PlayGame()
    {
        if (playerData.selectedCharacterPrefab == null)
        {
            Debug.LogWarning("No character selected. Please choose a character first.");
            return;
        }
        else
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    public void ChooseCharacter()
    {
        SceneManager.LoadScene("CharacterSelection");
    }
}
