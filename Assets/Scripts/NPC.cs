using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NPC : MonoBehaviour
{
     public CinemachineVirtualCamera VCamDisable;
    public CinemachineVirtualCamera VCamEnable;
    public GameObject UI;
    private PlayerMover _playerMover;
    private bool _canBuy = true;
    private float time = 1f;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if(_canBuy)
        {
            VCamDisable.gameObject.SetActive(false);
            VCamEnable.gameObject.SetActive(true);
            Camera.main.GetComponent<CinemachineBrain>().enabled =true;
            Camera.main.cullingMask &= ~(1 << 9); 
            _playerMover = other.GetComponent<PlayerMover>();
            _playerMover.canMove = false;
            UI.SetActive(true);
            _canBuy = false;
     
        }
        StartCoroutine(WaitForAbit());
    }

    public void ExitStore()
    {
        _playerMover.canMove = true;
        VCamDisable.gameObject.SetActive(true);
        VCamEnable.gameObject.SetActive(false);
        Camera.main.GetComponent<CinemachineBrain>().enabled = false;
        Camera.main.cullingMask |= (1 << 9);
        UI.SetActive(false);
    }

    private IEnumerator WaitForAbit()

    {
        yield return new WaitForSeconds(time);
        _canBuy = true;
    }

}
