using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour, ICollectable
{
       public void OnCollected()

    {
        GameManager.gameManager.OrbCollected();
        Destroy(gameObject);
    }

}
