using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coinCount = 0; // Toplanan coin sayısı
    [SerializeField] private Text coinText; // UI'deki coin sayısını gösterecek Text bileşeni

    public static CoinManager coinManagerInstance; // CoinManager scripti
    void Awake()
    {
        coinManagerInstance = this;
    }
    // Update is called once per frame
    void Update()
    {
        coinText.text = coinCount.ToString(); // Coin sayısını UI'de güncelle
    }
}
