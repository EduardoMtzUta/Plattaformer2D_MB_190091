using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    void Start()
    {
        GameManager.Instancia.player.transform.parent = null;
        GameManager.Instancia.player.transform.position = this.transform.position;
        GameManager.Instancia.player.playerMovement.Desbloquearcorrida();
    }
}
