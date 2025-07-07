using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour
{
    public Text coinText;

    void Start()
    {
        int totalCoins = CoinManager.coinManagerInstance.coinCount;
        coinText.text = totalCoins.ToString();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
