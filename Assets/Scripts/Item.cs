using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ICollectable
{
    public int ID;

    public void OnCollected()
    {
        GameManager.gameManager.ItemCollected(ID);
        Destroy(gameObject);
    }
}
