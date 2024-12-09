using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI CoinText, OrbText;
    public Image[] Items;
    public static GameManager gameManager;
    public int Orbs = 0, Coins = 0;
    

    private void Awake()
    {
        if (GameManager.gameManager != null && GameManager.gameManager != this)
        Destroy(gameObject);

        else

        {
            GameManager.gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void OrbCollected()

    {
        Orbs++;
        OrbText.text = "Orbs: " + Orbs;
    }
    public void CoinCollected()

    {
        Coins++;
        CoinText.text = "Coins: " + Coins;
    }

   public void ItemCollected (int id)

    {
        Items[id].gameObject.GetComponent<Image>().color = Color.white; 
    }
}
