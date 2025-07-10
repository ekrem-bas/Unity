using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour
{
    public Text gameCoinText;
    public Image bloodImage;
    public Text coinText;
    public Canvas gameOverCanvas;

    public void ShowGameOver()
    {
        gameCoinText.enabled = false;
        bloodImage.enabled = false;
        int totalCoins = CoinManager.coinManagerInstance.coinCount;
        coinText.text = totalCoins.ToString();
        gameOverCanvas.gameObject.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
