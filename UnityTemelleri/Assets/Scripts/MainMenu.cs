using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        if (PlayerPrefs.GetString("SelectedCharacterName") == "")
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
