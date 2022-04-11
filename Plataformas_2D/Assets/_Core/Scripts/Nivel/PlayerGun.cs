using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public GameObject lootUIPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag != Constantes.TAG_PLAYER){return;}
        GameManager.Instancia.lootUI.transform.position = lootUIPos.transform.position;
        GameManager.Instancia.lootUI.gameObject.SetActive(true); 
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag != Constantes.TAG_PLAYER){return;}
        GameManager.Instancia.lootUI.gameObject.SetActive(false); 
    }
}
