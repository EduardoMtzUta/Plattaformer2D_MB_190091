using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public GameObject lootUIPos;
    private bool isActive = false;
    void Update()
    {
        if(!isActive){return;}
        if (Input.GetKeyDown(KeyCode.E))
        {
            RealizarAccion();
        }
    }
    private void RealizarAccion(){
        gameObject.SetActive(false);
        GameManager.Instancia.player.pistola.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag != Constantes.TAG_PLAYER){return;}
        isActive = true;
        GameManager.Instancia.lootUI.transform.position = lootUIPos.transform.position;
        GameManager.Instancia.lootUI.gameObject.SetActive(true); 
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag != Constantes.TAG_PLAYER){return;}
        isActive = false;
        GameManager.Instancia.lootUI.gameObject.SetActive(false); 
    }
}
